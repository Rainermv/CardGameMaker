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

namespace CGMEditor
{
	public class ActionEditorNodeBufferLoad : ActionEditorNodeGroup
	{
		public ActionEditorNodeBufferLoad (CGME.Action act) : base(act)
		{

		}
		
		public override void DrawAsInspector(){
		
			base.DrawAsInspector();
		
			CGME.ActionBufferLoad action_select = (action as CGME.ActionBufferLoad);
		
			
				EditorGUILayout.BeginHorizontal();
				{
					//action.Source = (CGME.SelectionSource)(EditorGUILayout.EnumPopup("Source", action.Source)) ;
					action_select.LoadType = (CGME.BufferLoadType)(Display.EnumPopup(this,"Load Type", action_select.LoadType)) ;
					
					switch (action_select.LoadType){
					case CGME.BufferLoadType.Index:
						//action.SourceCGType = EditorGUILayout.TextField("CGType",action.SourceCGType);
						action_select.LoadIndex = Display.IntField(this,"Index",action_select.LoadIndex);
						break;
					
					}
				}	
				EditorGUILayout.EndHorizontal();
			
		}
	}
}

