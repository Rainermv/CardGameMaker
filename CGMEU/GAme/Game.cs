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
	public class Game : CGMObject, CGME.IEngineListener
	{
		[SerializeField]
		private string ruleset;
		
		[SerializeField]
		private CGME.Game CGME_game = new CGME.Game();
		
		public CGME.Game CGME_Game{
			get{return CGME_game;}
			set{CGME_game = value;}
		}
		
		public string RuleSet{
			get{return ruleset;}
			set{ruleset = value;}
		}
		
//		[SerializeField]
//		private List<Phase> phases = new List<Phase>();
//		
//		public List<Phase> Phases {
//			get {return phases;}
//			set {phases = value;}
//		}
//		
//		public Phase GetPhase(int index){
//			return phases[index];
//		}
//		
		protected override void SetListener(){
			
			CGME_game.AddListener(this);
			
		}
		
		public override void SetObject(CGME.CGObject cgobj){
			CGME_game = (CGME.Game) cgobj;
		}
		
		
//		
//		protected override void RegisterChildren(){
//			RegisterPlayers();
//			RegisterPhases();
//		
//		}
		
		
//		void RegisterPlayers(){
//	
//			CGM.Player[] children = (CGM.Player[])transform.GetComponentsInChildren<CGM.Player>();
//			
//			//CGME.GameManager manager = CGME.GameManager.GetInstance();
//			foreach (CGM.Player child in children){
//				CGME_game.AddPlayer(child.CGME_Player);
//			}
//			
//			Debug.Log ("Register players: " + CGME_game.Players_Size);
//		
//		}
		
		
//		void RegisterPhases(){
//			foreach (CGM.Phase cgm_phase in Phases){
//				CGME_game.AddPhase(cgm_phase.CGME_Phase);
//			}
//			
//			Debug.Log ("Register phases: " + CGME_game.Phases_Size);
//		}

		public void Register(CGMObject parent){
		
			RegisterResources ();
			
			for (int i = 0; i<transform.childCount; i++){
				transform.GetChild(i).SendMessage("Register", this, SendMessageOptions.DontRequireReceiver);
			}
						
			SetListener();
		
		}
		
		
		protected override void RegisterResource (CGM.Resource res){
			Debug.Log("Error in " + name+ " - Resources in Game are not allowed");
		}

		
		void CGME.IEngineListener.Act(CGME.EngineEvent ee, CGME.CGObject source, CGME.CGObject param1, CGME.CGObject param2){
			switch (ee){
				case CGME.EngineEvent.AddChild: 
					AddChild (param1, "Player");
					break;
				case CGME.EngineEvent.AddResource:
					AddChild (param1, "Resource");
					break;
			
			}
		}
		
		
//		protected override void RegisterChild(CGMObject child){
//			if (child is CGM.Player){
//				CGM.Player player = (CGM.Player)child;
//				CGME_game.AddPlayer(player.CGME_Player);
//			}
//		}
		
//		protected override void ReportEvent(CGME.InterfaceEvent ev){
//			input_listener.ReportEvent(ev,this);
//		}
		
		public override void Write(){
			if (CGME_game != null){
				node.type_string = CGME_game.GetType().ToString();
				node.data = CGME_game.Write();
			}
		}
		
		public override void Read(){
			
			if (node != null){
				CGME_game = new CGME.Game();
				CGME_game.Read(node.data);
			}
			
		}
		
		public string[] GetPhases(){
			List<string> phases = new List<string>();
			for (int i = 0; i < transform.childCount; i++){
				Phase ph = transform.GetChild(i).GetComponent<Phase>();
				
				if (ph != null)	
					phases.Add(ph.name);
			}
			return phases.ToArray();
		}
		
		protected override void CleanUp(){
			if (CGME_Game.Cleanup() == true){
				CGME_Game = null;
				Destroy(gameObject);
			}		
		}
		
		
		
				
	}
}

