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
namespace CGME
{
	
//	public enum InterfaceEvent {Always, MouseDown, MouseDrag, MouseEnter, MouseExit, 
//		MouseOver,  MouseUp, MouseUpButton}
		
		
	public class ResourceAction : CGME.Resource{
	
		private int phase;
		
		private Action action = new ActionGroup();
		
		public Action Value {get{return action;} set {action = value;}}
		public int Phase{get{return phase;} set {phase = value;}}
		
		//private int trigger;
		
		private int action_index;
		
		public int ActionIndex{
			get{return action_index;}
			set{action_index = value;}
		}
		
//		public int Trigger{
//			get{return trigger;}
//			set{trigger = value;}
//		}
		
		public ResourceAction(){
			phase = 0;
			//action = new ActionGroup();
			enabled = true;
			cgtype = "Name";
			//trigger = 0;
		}
//		public ResourceAction(string phase, Action action, bool enabled = true){
//			this.phase = phase;
//			this.action = action;
//			this.enabled = enabled;
//			
//			this.name = name;
//			//AddAction ();
//		}
		
//		public void AddAction(){
//			GameManager.GetInstance ().AddAction(action, phase);
//			DispatchEvent(EngineEvent.ModifyResource, null, null);
//		}
//		
//		public void RemoveAction(){
//			GameManager.GetInstance ().RemoveAction(action, phase);
//			DispatchEvent(EngineEvent.ModifyResource, null, null);
//		}
		
		public override void Enable (bool enable)
		{
			this.enabled = enable;
			
			//if (enable) AddAction();
			//else 		RemoveAction();
		}
		
		public override string ToString(){
			return (action.CGType + " : " + phase);
		}
		
//		public override byte[] ToBytes(){
//			
//			if (action == null) return null;
//			
//			//byte[] myByteArray = new byte[10];
//			
//			System.IO.MemoryStream stream = new System.IO.MemoryStream();
//			System.IO.BinaryWriter writer = new System.IO.BinaryWriter(stream);
//			
//			writer.Write(phase);
//			writer.Write (action.GetType().FullName);
//			return stream.ToArray();
//			
//		}
//		public override void Read(byte[] FromBytes){
//			
//			if (FromBytes == null) return;
//			
//			System.IO.MemoryStream stream = new System.IO.MemoryStream(FromBytes);
//			System.IO.BinaryReader reader = new System.IO.BinaryReader(stream);
//			
//			phase = reader.ReadString();
//			string action_name = reader.ReadString();
//			
//			action = Activator.CreateInstance(Type.GetType(action_name)) as Action;
//		}

		public override void SaveParameters(System.IO.BinaryWriter writer){
			base.SaveParameters(writer);
			
			writer.Write (action_index);
			
			writer.Write (phase);
			//writer.Write (Trigger);
			//writer.Write(action.GetType().FullName);
			//action.Write(name);
		}
		
		public override void LoadParameters(System.IO.BinaryReader reader){
			base.LoadParameters(reader);
			
			action_index = reader.ReadInt32 ();
			
			phase = reader.ReadInt32();
			//trigger = reader.ReadInt32();
			//string action_name = reader.ReadString();
			//action = Activator.CreateInstance(Type.GetType(action_name)) as Action;
		}
		
		public bool IsAvailable(int phase_index){
			
			return (Value.IsArmed && this.phase == phase_index);
		
		}
		
		public void RunAction(Actor source, Actor p){
			
			int current_phase = GameManager.GetInstance().Running_phase.Index;
			
			//GameManager.DebugLog ("Phase is " + this.phase);
			
			if (this.phase == current_phase || this.phase == -1){
				//GameManager.DebugLog ("Running Action");
				Value.Run (source, p, null);
					//GameManager.DebugLog ("Action had Run");
			}
		}
	}
}

