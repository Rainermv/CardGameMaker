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
using System.Collections.Generic;
using UnityEngine;

namespace CGM
{
	
	public class PopUpWindow
	{
		struct PopUpButton{
			public Rect rect;
			public string text;
			public int index;
			
		}
		
		float x;
		float y;
		
		float width = 100;
		float height = 20;
		
		Camera cam;
		
		private List<PopUpButton> buttons = new List<PopUpButton>();
		
		public PopUpWindow(string[] options, Vector3 position){
			
			cam = GameObject.FindObjectOfType<Camera>();
			//position = cam.WorldToScreenPoint(position);
			
			this.x = position.x;
			this.y = Screen.height -position.y;
			
			if (y + (height * options.Length) > Screen.height){
				y = Screen.height - (height * options.Length);
			}
			
			if (x + width > Screen.width){
				x = Screen.width - width;
			}
						
			float y2 = y;
					
			int index = 0;
			foreach (string opt in options){
				PopUpButton button = new PopUpButton();
				button.rect = new Rect(x, y2,width,height);
				button.text = opt;
				
				button.index = index++;
				y2 += height;
				
				buttons.Add (button);
			}

		}
		
		public int Draw(){
			
			//GUI.Box (new Rect(x,y,width,heigth/*buttons.Count*/), "This is a window");
			
			foreach (PopUpButton button in buttons){
				if (GUI.Button(button.rect,button.text))
					return button.index;
			}
			
			return -1;
		}
		
		public bool InsideBoundaries(Vector2 position){
			float pos_x = position.x;
			float pos_y = Screen.height - position.y;
			
			float t_height = height * buttons.Count;
			
			return (pos_x >= x && pos_x <= x + width &&
				    pos_y >= y && pos_y <= y + t_height);		
		}
	}
}
