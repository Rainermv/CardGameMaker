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
	public class ActionEditorNodeComparable: ActionEditorNode
	{
		public ActionEditorNodeComparable (CGME.Action act) : base(act)
		{

		}
		
		public override void DrawAsInspector(){
		
			base.DrawAsInspector();
		
			CGME.ActionConditionComparable act = (action as CGME.ActionConditionComparable);
			
			EditorGUILayout.BeginHorizontal();
			{
				act.Objects[0] = (CGME.SelectionSource)Display.EnumPopup(this,"Object 1",act.Objects[0]);
				if (act.Objects[0] == CGME.SelectionSource.Type)
					act.ObjectStrings[0] = Display.TextField(this,"Parent Type", act.ObjectStrings[0]);
			}
			EditorGUILayout.EndHorizontal();
			
			EditorGUILayout.BeginHorizontal();
			{
				act.Objects[1] = (CGME.SelectionSource)Display.EnumPopup(this,"Object 2",act.Objects[1]);
				if (act.Objects[1] == CGME.SelectionSource.Type)
					act.ObjectStrings[1] = Display.TextField(this,"Parent Type", act.ObjectStrings[1]);
			}
			EditorGUILayout.EndHorizontal();
			
		}
	}
}

