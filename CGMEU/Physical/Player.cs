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
	public enum Controller {AI, Disabled, Local, Network }
	
	[Serializable]
	public class Player : CGMObject, CGME.IEngineListener
	{
		public CGME.Player CGME_Player = new CGME.Player();
		
		[SerializeField]
		public SerialNode the_node = new SerialNode();
		
		public override void SetObject(CGME.CGObject cgobj){
			CGME_Player = (CGME.Player) cgobj;
		}
		
		public override CGME.Actor GetCGMEActor(){
			return CGME_Player as CGME.Actor;
		}
		
		protected override void SetListener(){
			
			CGME_Player.AddListener(this);
		
		}
		
		protected void RegisterDecks(){
		
			CGM.Deck[] children = (CGM.Deck[])transform.GetComponentsInChildren<CGM.Deck>();
			
			//CGME.GameManager manager = CGME.GameManager.GetInstance();
			foreach (CGM.Deck child in children){
				CGME_Player.AddDeck(child.CGME_Deck);
			}
		
		}

//		protected override void RegisterChild(CGMObject child){
//			if (child is CGM.Player){
//				CGM.Deck obj = (CGM.Deck)child;
//				CGME_Player.AddDeck(obj.CGME_Deck);
//			}
//		}
//		
//		protected override void RegisterResources(){
//			//CGM.Resource[] children = (CGM.Resource[])transform.GetComponentsInChildren<CGM.Resource>();
//			
//			//CGME.GameManager manager = CGME.GameManager.GetInstance();
//			//foreach (CGM.Resource child in children){
//			for (int i = 0; i <transform.childCount; i++){
//				CGM.Resource res = transform.GetChild (i).GetComponent<CGM.Resource>();
//				if (res != null)
//					CGME_Player.AddResource(res.CGME_Resource);
//			}
//		}

		protected void Register(Game game){
			
			RegisterResources ();
			
			game.CGME_Game.AddPlayer(CGME_Player);
			
			for (int i = 0; i<transform.childCount; i++){
				transform.GetChild(i).SendMessage("Register", this, SendMessageOptions.DontRequireReceiver);
			}
			
			SetListener();
			
		}
		
		protected override void RegisterResource (CGM.Resource res){
			CGME_Player.AddResource(res.CGME_Resource);
		}
		
//		void Start(){
//			
//			//RegisterChildren();
//			RegisterDecks();
//			RegisterResources();
//			SetListener ();
//			
//		}
		
		
		void CGME.IEngineListener.Act(CGME.EngineEvent ee, CGME.CGObject source, CGME.CGObject param1, CGME.CGObject param2){
			switch (ee){
			case CGME.EngineEvent.SetId: 
				ID = param1.Id;
				break;
			case CGME.EngineEvent.AddChild: 
				AddChild (param1, "Deck");
				break;
			case CGME.EngineEvent.AddResource:
				AddChild (param1, "Resource");
				break;
				
			}
		}
		
//		protected override void ReportEvent(CGME.InterfaceEvent ev){
//			input_listener.ReportEvent(ev,this);
//		}

		public override void Write(){
			if (CGME_Player != null){
				node.type_string = CGME_Player.GetType().ToString();
				node.data = CGME_Player.Write();
			}
			//node.type = CGME_resource.GetType();
			//node.type_string = CGME_Player.GetType().ToString();
		}
		
		public override void Read(){
			//CGME.Player new_obj = CGME.CGFactory.Instantiate(node.type_string) as CGME.Player;
						
			if (node != null){
				CGME_Player = new CGME.Player();
				CGME_Player.Read(node.data);
			}
			
			//new_obj = null;
		}
		
		protected override void CleanUp(){
			if (CGME_Player.Cleanup() == true){
				CGME_Player = null;
				Destroy(gameObject);
			}		
		}
		
	}
}
