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

namespace CGMEditor
{
	[CustomEditor(typeof(CGM.Player))]
	public class PlayerInspector : CGMObjectInspector
	{
	//	public override void OnInspectorGUI()
	//	{
	//		CGMEU.Card Target = (CGMEU.Card)target;
	//		
	//		Target.name = EditorGUILayout.TextField("Name", Target.name);
	//		EditorGUILayout.LabelField("Resources");
	//		foreach (CGMEU.Resource res in Target.Resources){
	//			EditorGUILayout.BeginHorizontal();
	//				res.name = EditorGUILayout.TextField(res.name);
	//				
	//				if (res.Resource_type ==  CGMEU.ResourceType.Number){
	//					CGME.ResourceNumber cgres = (CGME.ResourceNumber)res.CGME_Resource;
	//					cgres.Value = EditorGUILayout.IntField (cgres.Value);
	//				}
	//				else if (res.Resource_type ==  CGMEU.ResourceType.Text){
	//					CGME.ResourceText cgres = (CGME.ResourceText)res.CGME_Resource;
	//					cgres.Value = EditorGUILayout.TextField (cgres.Value);
	//				}
	//				else if (res.Resource_type ==  CGMEU.ResourceType.Bool){
	//					CGME.ResourceBool cgres = (CGME.ResourceBool)res.CGME_Resource;
	//					cgres.Value = EditorGUILayout.Toggle (cgres.Value);
	//				}
	//				else if (res.Resource_type ==  CGMEU.ResourceType.Action){
	//					CGME.ResourceAction cgres = (CGME.ResourceAction)res.CGME_Resource;
	//					//cgres.Value = EditorGUILayout.TextArea.Field (cgres.Value);
	//					EditorGUILayout.LabelField (cgres.Value.Name);
	//				}
	//				
	//			
	//			EditorGUILayout.EndHorizontal();
	//		}
	//		
	//		
	//		//EditorGUILayout.LabelField("Level", myTarget.Level.ToString());
	//	}
	
		public override void DrawObject(CGM.CGMObject Target){
			
			CGM.Player t = (CGM.Player)target;
			t.CGME_Player.CGType = EditorGUILayout.TextField("Type",t.CGME_Player.CGType);
			Target.gameObject.name = t.CGME_Player.CGType;
		}
	}
}

