using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomPropertyDrawer (typeof (MixerExposedParameter))]
public class MixerExposedParameterPropertyDrawer : PropertyDrawer
{
	private static int LINE_HEIGHT = 16;
	private static int SPACING = 2;

	private List<string> getExposedParameterNames(Object mixerObject)
	{
		SerializedObject serializedObject = new SerializedObject(mixerObject);
		SerializedProperty exposedParameters = serializedObject.FindProperty("m_ExposedParameters");

		if (exposedParameters == null)
		{
			Debug.LogWarning ("No exposed parameters variable for " + mixerObject.name);
			return null;
		}

		if (!exposedParameters.isArray)
		{
			Debug.LogWarning ("Exposed parameters is not an array for " + mixerObject.name);
			return null;
		}

		//Construct Exposed Parameters Name List
		List<string> exposedParameterNames = new List<string> (exposedParameters.arraySize);
		for (int i = 0; i < exposedParameters.arraySize; i++)
		{
			SerializedProperty parameter = exposedParameters.GetArrayElementAtIndex (i);
			exposedParameterNames.Add (parameter.FindPropertyRelative ("name").stringValue);
		}
		return exposedParameterNames;
	}

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty (position, label, property);

		Rect mixerRect = new Rect (position.x, position.y, position.width, LINE_HEIGHT);
		Rect exposedParameterRect = new Rect (position.x, position.y+LINE_HEIGHT+SPACING, position.width, LINE_HEIGHT);

		SerializedProperty mixerProperty = property.FindPropertyRelative ("audioMixer");
		SerializedProperty variableNameProperty = property.FindPropertyRelative ("mixerVariableName");
		GUIContent mixerContent = new GUIContent (mixerProperty.displayName);
		EditorGUI.PropertyField (mixerRect,mixerProperty, mixerContent,false);
		if (mixerProperty.objectReferenceValue != null)
		{
			List<string> exposedParameterOptions = new List<string>();
			exposedParameterOptions.Add ("Not selected");
			exposedParameterOptions.AddRange(getExposedParameterNames (mixerProperty.objectReferenceValue));

			int index = 0;
			if (variableNameProperty.stringValue.Trim ().Length > 0)
			{//If there IS a variable
				index = exposedParameterOptions.IndexOf (variableNameProperty.stringValue);
				if (index == -1)
				{//If variable was not present in mixer variables
					//Consider adding it to variables but marking it as not present in the current mixer
					index = 0;//For now just change to not selected
				}
			}

			int newIndex = EditorGUI.Popup (exposedParameterRect,variableNameProperty.displayName, index, exposedParameterOptions.ToArray());
			if (newIndex > 0)
			{
				variableNameProperty.stringValue = exposedParameterOptions [newIndex];
			}
		}
		else
		{
			EditorGUI.LabelField (exposedParameterRect,
				"Select an AudioMixer to see a list of exposed variables for that Mixer.");
			// Maybe when there's no mixer the variable should be removed?
			variableNameProperty.stringValue = "";
		}
		EditorGUI.EndProperty ();
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return LINE_HEIGHT * 2 + SPACING;
	}
}
