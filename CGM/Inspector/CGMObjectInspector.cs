using System;
using UnityEditor;
using UnityEngine;

namespace CGMEditor
{
	
	
	[CustomEditor(typeof(CGM.CGMObject))]
	public abstract class CGMObjectInspector : Editor 
	{
		
		CGM.Resource[] resources = null;
		CGM.CGMObject Target;
		
		protected virtual void OnEnable(){
			
			Target = (CGM.CGMObject)target;
			resources = Target.GetChildrenResources();
			
			//library = FindObjectOfType<CGM.Library>();
		}
		
		
		public override void OnInspectorGUI()
		{
					
			DrawObject (Target);

			EditorGUILayout.LabelField("Resources");
			
			EditorGUI.indentLevel++;
			
			foreach (CGM.Resource res in resources){
	
				EditorGUILayout.BeginHorizontal();
				
				
				if (res.CGME_Resource == null){ 
					EditorGUILayout.LabelField("Resource Null");
					continue;
				}
				else
					EditorGUILayout.LabelField(res.CGME_Resource.CGType);
				
				if (res.Resource_type ==  CGM.ResourceType.Number){
					CGME.ResourceNumber cgres = (CGME.ResourceNumber)res.CGME_Resource;
					cgres.Value = EditorGUILayout.IntField (cgres.Value);
					//cgres.SetValue(EditorGUILayout.IntField (cgres.Value));
				}
				else if (res.Resource_type ==  CGM.ResourceType.Text){
					CGME.ResourceText cgres = (CGME.ResourceText)res.CGME_Resource;
					cgres.Value = EditorGUILayout.TextField (cgres.Value);
				}
				else if (res.Resource_type ==  CGM.ResourceType.Bool){
					CGME.ResourceBool cgres = (CGME.ResourceBool)res.CGME_Resource;
					cgres.Value = EditorGUILayout.Toggle (cgres.Value);
				}
				else if (res.Resource_type ==  CGM.ResourceType.Action){
					CGME.ResourceAction cgres = (CGME.ResourceAction)res.CGME_Resource;
					//cgres. = EditorGUILayout.TextArea.Field (cgres.Value);
					
					//EditorGUILayout.LabelField (library.GetAction(cgres.ActionIndex).name);
				}
				
				
				EditorGUILayout.EndHorizontal();
				
			}
			EditorGUI.indentLevel--;
			
			//EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
		}
		
		public virtual void DrawObject(CGM.CGMObject Target){
			return;
		}
		
	}
}
