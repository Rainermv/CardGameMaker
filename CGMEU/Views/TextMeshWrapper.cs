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
using UnityEngine;

namespace CGM
{
	public class TextMeshWrapper : ComponentWrapper
	{
		private TextMesh text_mesh_component;
		
		public override void Init(GameObject parent){
			
			text_mesh_component = parent.GetComponent<TextMesh>();
			
			//if (text_mesh_component == null)
			//	text_mesh_component = parent.AddComponent<TextMesh>();
				
		}
		
	
		public override void Update(string value){
			if (text_mesh_component == null){
				//Debug.LogWarning("TextMesh Wrapper have a null component");
				return;
			}
			
			text_mesh_component.text = value ;
		}
	}
}

