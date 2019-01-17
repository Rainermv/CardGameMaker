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

namespace CGMEditor
{
	public static class NodeLevelCounter
	{
		public class Level{
				public float y;
				public int count;
				
				public int getters;
				public float run_x;
				//public float[] x_array;
				
				public Level(float y){
					this.y = y;
					count = 0;
					getters = 0;
					run_x = -1f;
				}
				
				public float GetX(){
					if (run_x == -1){
						//x_array = new float[count];
												
						run_x = NodeLevelCounter.GetLargerLevel() *0.5f - ((float)count * 0.5f);
					}
					
					float return_value = run_x + getters;
					getters++;
					
					return return_value;
				}
			
		}
		//static List<int> levels = new List<int>();
		static List<Level> levels = new List<Level>();
		
		public static void AddLevel(){
			levels.Add (new Level(levels.Count));
		}
		
		public static void CountLevel(int ind){
			if (ind >= levels.Count){
				AddLevel ();
			} 
			levels[ind].count += 1;
		}
		
		public static void CountLevel(int ind, int num){
			if (ind >= levels.Count){
				AddLevel ();
			} 
				levels[ind].count += num;
		}
		
		public static Level GetLevel(int ind){
			if (levels.Count > ind) {
				return levels[ind];
			}
			return null;
		}
		
		public static float GetLevelX(int ind){
			if (levels.Count > ind) {
				return levels[ind].GetX();
			}
			return 0f;
		}
		
		public static float GetLevelY(int ind){
			if (levels.Count > ind) {
				return levels[ind].y;
			}
			return 0f;
		}
		
		public static int GetLargerLevel(){
			int larger = 0;
			foreach (Level l in levels){
				if (l.count > larger) larger = l.count;
			}
			return larger;
		}
		
		public static void Clear(){
			levels.Clear();
		}
		
		public static void DebugLevels(){
			
			int i = 0;
			foreach (Level l in levels){
				Debug.Log("Level " + i++ + " :: Y: " + l.y + " | X: " + l.run_x + " | C: " + l.count + " | g: " + l.getters);
			}
		}
	}
}
