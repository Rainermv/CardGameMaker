//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.544
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
//using Action;

namespace CGME
{
	//[Serializable]
	public class Phase : CGME.Actor

	{
		public Phase(){
			cgtype = "New Phase";
			enabled = true;
			
			iterator = 0;
//			
//			init = false;
			finished = false;
		}
		//CONSTANT ----------------------------------------
//		private const int PRIORITY_MIN = 0;
//		private const int PRIORITY_MAX = 10;

		//PRIVATE VARIABLES -------------------------------

		private int index;

		//private int priority;
		private int iterator;

//		private bool init;
		private bool finished;
		private List<CGME.Action> actions = new List<CGME.Action>();

		// CONSTRUCTORS ----------------------------------
	
//		public Phase(string name, bool enabled = true){
//			Name = name;
//			this.enabled  = enabled;
//
//			//Priority = 0;
//			iterator = 0;
//
//			init = false;
//			finished = false;
//		}

		// GET/SET FUNCTIONS -----------------------------

		public bool IsFinished{
			get{return finished;}
		}
//
//		public bool Init{
//			get{return init;}
//			//set{init = value;}
//		}
//		

		public List<CGME.Action> Actions{
			get{return actions;}
		}

//		public bool End{
//			get {return end;}
//			set {end = value;}
//		}

//		public int Priority
//		{
//			get { return priority;}
//			set {
//				if (value < PRIORITY_MIN)		priority = PRIORITY_MIN;
//				else if (value > PRIORITY_MAX) 	priority = PRIORITY_MAX;
//				else 							priority = value;
//			}
//		}

		public int Index{
			get  {return index;}
			set {index = value;}
		}

		public Action GetAction(CGME.Action _action){
				
			foreach (Action action in actions) {
				if (action == _action)
					return action;
			}
			
			return null;
		}

		public Action GetAction(string name){
			
			foreach (Action action in actions) {
				if (action.CGType == name)
					return action;
			}
			
			return null;
		}

		public Action GetAction(int index){
			return actions[index];
		}

		public int Actions_Size{
			get { return actions.Count;}
		}

		// LIST FUNCTIONS ----------------------------------------
		
		public override CGObject AddChild(CGObject child){
			if (child is Action){
				child.Parent = this;
				return AddAction (child as Action);
			}
			
			return null;
		}
		
		public override void RemoveChild(CGObject child){
			if (child is Action)
				RemoveAction (child as Action);
		}

		public Action AddAction(CGME.Action new_action){
			//DispatchEvent(EngineEvent.AddChild, new_action, null);
			actions.Add(new_action);
			
			new_action.Parent = this;
	
			return new_action;
		}

		public void RemoveAction(CGME.Action action){
			actions.Remove(action);
		}

		public void RemoveAction(int index){
			actions.RemoveAt(index);
		}

		public void ClearActions(){
			actions.Clear();
		}

		// PRIVATE FUNCTIONS -------------------------------------
		
		public void Init(){
		
			foreach (Action action in actions){
				action.Arm ();
			}
			
			finished = false;
		}

		public void Run()
		{

			foreach (Action action in actions){
				action.Run(this, null, null);
			}
			
		} 

		public void End()
		{
			//finished = true;
//			foreach (Action action in actions){
//				action.Disarm();
//			}
			
			finished = true;

		}

		// PUBLIC FUNCTIONS -------------------------------------
		
		public override void EnableChildren(bool enable){
			
			foreach (Action action in actions){
				action.Enable(enable);
			}
		}

//		public CGME.Action NextAction(){
//		
//			CGME.Action action = GetAction(iterator);
//			Iterate();
//			return action;
//		}
		// Check and run the game actions
//		public bool RunActions()
//		{
//			foreach (CGME.Action action in Actions){
//			    			
//			    action.Run(this, null, null);
//			    	
//			}
//			
//			return false;
//		}
//
//		public void Update()
//		{
//			// CHECK ALL THE ACTIONS
//			RunActions();
//			
//		}
//		
		public override CGObject FindChildren(string name){
			
			foreach (CGObject child in actions){
				CGObject found = child.FindObject(name);
				if (found != null) return found;
				
			}
			return null;
		}
		
		public override CGObject FindChildren(int id){
			
			foreach (CGObject child in actions){
				CGObject found = child.FindObject(id);
				if (found != null) return found;
				
			}
			return null;
		}
		
		public override void StartChildren(){
			foreach (CGObject child in actions)
				child.Start ();
		}
		
		public override void ClearChildren(){
			actions.Clear();
		}
		public override void CleanupChildren(){
			for (int i = 0; i < actions.Count; i++){
				if (actions[i].DestroyFlag){
					actions.RemoveAt(i);
					break;
				}
			}
		}


	}
}

