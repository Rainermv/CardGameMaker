//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.18444
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

namespace CGMEditor
{
	[CustomEditor(typeof(CGM.Resource))]
	public class ResourceInspector : Editor 
	{
		// = new ResourceType();
		//CGM.ResourceType res;
		
		CGM.Game game;
		CGM.GameManager manager;
		CGME.CGLibrary library;
		
		
		List<string> phase_names = new List<string>();
		//int phase_index;
				
		
		int res_index;
		string res_string;
		
		CGM.Resource Target;

		void OnEnable(){
			
			Target = (CGM.Resource)target;
			
			game = FindObjectOfType<CGM.Game>();
			if (game == null){
				Debug.LogWarning("No Game component found");
				return;
			}
			
			manager = FindObjectOfType<CGM.GameManager>();
			if (manager == null){
				Debug.LogWarning("No GameManager component found");
				return;
			}

			library = manager.CGME_Lib;
						
			phase_names.Clear();
			phase_names.Add("Any");
			phase_names.AddRange(game.GetPhases());
			res_string = "resource";
						
			if (library.resourceLibrary.Count == 0)
				return;
			
			if (Target.CGME_Resource == null)
				Target.CGME_Resource = CGME.CGFactory.CreateCGInstance(library.GetResource(0).GetType().FullName) as CGME.Resource;
		}
		
		int GetPhaseIndex(){
			if (Target.CGME_Resource is CGME.ResourceAction)
				return (Target.CGME_Resource as CGME.ResourceAction).Phase+1;
			return 0;
		}
		
		int SetPhaseIndex(int ph){
			return ph-1;
		}
						
		public override void OnInspectorGUI()
		{
			
			
			if (library.resourceLibrary.Count == 0){
			
				EditorGUILayout.LabelField("Resource library is empty");
				EditorGUILayout.LabelField("Add some resources to the game manager first");
				
				return;

			}
			
			
//			if (Target.Resource_type == CGM.ResourceType.Empty){
//				Target.CGME_Resource = CGME.CGFactory.CreateCGInstance(library.GetResource(0).GetType().FullName) as CGME.Resource;
//				Target.CGME_Resource.CGType = res_string;
//			}

			EditorGUILayout.LabelField(Target.CGME_Resource.CGType);
			Target.name = Target.CGME_Resource.CGType;
			
			ResourceField(Target.CGME_Resource);
			
			EditorGUILayout.Space();

			EditorGUILayout.LabelField("Switch Resource");
			EditorGUILayout.BeginHorizontal();
			
			res_index = EditorGUILayout.Popup("Type",res_index, library.ResourceTypes());
			res_string = library.resourceLibrary[res_index].CGType;
			
			if (GUILayout.Button("Switch to " + res_string)){
				CGME.Resource resource = library.GetResource(res_index);
				if (resource != null){
					Target.CGME_Resource = CGME.CGFactory.CreateCGInstance(library.GetResource(res_index).GetType().FullName) as CGME.Resource;
					Target.CGME_Resource.CGType = res_string;
					
					if (Target.CGME_Resource is CGME.ResourceAction){
						(Target.CGME_Resource as CGME.ResourceAction).ActionIndex = (resource as CGME.ResourceAction).ActionIndex;	
						//phase_index = GetPhaseIndex();
					}
				}
			}
			
			EditorGUILayout.EndHorizontal();
		}
		
		public void ResourceField (CGME.Resource res){
			
			if (res is CGME.ResourceNumber){
				//CGME.ResourceNumber cgres = (CGME.ResourceNumber)Target.CGME_Resource;
				(res as CGME.ResourceNumber).Value = EditorGUILayout.IntField ((res as CGME.ResourceNumber).Value);
			}
			else if (res is CGME.ResourceText){
				(res as CGME.ResourceText).Value = EditorGUILayout.TextField ((res as CGME.ResourceText).Value);
			}
			else if (res is CGME.ResourceBool){
				(res as CGME.ResourceBool).Value = EditorGUILayout.Toggle ((res as CGME.ResourceBool).Value);
			}
			else if (res is CGME.ResourceAction){
				DrawResourceAction();
			}
			
			//EditorGUILayout.EndHorizontal();
			
		}
	
		void DrawResourceAction(){
			
			CGME.ResourceAction cgres = (CGME.ResourceAction)Target.CGME_Resource;
			
			//Target.Action_Object =  (CGM.Action)EditorGUILayout.ObjectField("Action",Target.Action_Object ,typeof(CGM.Action),true);

			//cgres.Phase = EditorGUILayout.Popup("Phase",cgres.Phase,phase_names.ToArray());
			
			int phase_index = GetPhaseIndex();
			phase_index = EditorGUILayout.Popup("Phase",phase_index,phase_names.ToArray());
			cgres.Phase = SetPhaseIndex(phase_index);
			
			//EditorGUILayout.BeginHorizontal();
			EditorGUILayout.BeginHorizontal();
			Target.RestrictParent = EditorGUILayout.Toggle("Restrict Parent", Target.RestrictParent);
			if (Target.RestrictParent)
				Target.ParentType = EditorGUILayout.TextField("Parent Type",Target.ParentType);
			EditorGUILayout.EndHorizontal();
			
			Target.Trigger = (CGM.InterfaceEvent)EditorGUILayout.EnumPopup("Trigger",Target.Trigger);
			
		}
	}
}

