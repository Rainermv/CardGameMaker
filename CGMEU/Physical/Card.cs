//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.18408
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace CGM
{
	[Serializable]
	public class Card : CGMObject, CGME.IEngineListener
	{
		[SerializeField]
		private CGME.Card CGME_card = new CGME.Card();
		public CGME.Card CGME_Card {get{return CGME_card;}set{CGME_card = value;}}
		public string parent;
		
		[UnityEngine.SerializeField]
		protected SerialNode the_node = new SerialNode();
		
		protected override void SetListener(){
			
			CGME_Card.AddListener(this);
			
		}
		
		public override void SetObject(CGME.CGObject cgobj){
			CGME_Card = (CGME.Card) cgobj;
		}
		
		public override CGME.Actor GetCGMEActor(){
			return CGME_Card as CGME.Actor;
		}

		protected void Register(Deck deck){
			
			RegisterResources ();
			
			deck.CGME_Deck.AddCard(CGME_Card);
			
			SetListener();
						
		}
		
		protected override void RegisterResource (CGM.Resource res){
			CGME_Card.AddResource(res.CGME_Resource);
		}
				
		void CGME.IEngineListener.Act(CGME.EngineEvent ee, CGME.CGObject source, CGME.CGObject param1, CGME.CGObject param2){
			switch (ee){
			case CGME.EngineEvent.SetId: 
				ID = param1.Id;
				break;
			
			case CGME.EngineEvent.AddResource: 
				AddChild (param1, "Resource");
				break;
				
			case CGME.EngineEvent.BufferSelect: 
				renderer.material.color = Color.gray;
				break;
			
			
			case CGME.EngineEvent.BufferRemove: 
				renderer.material.color = Color.white;
				break;
				
			}
		
		}
		
//		protected override void ReportEvent(CGME.InterfaceEvent ev){
//			input_listener.ReportEvent(ev,this);
//		}
		
		/*
		protected override void SetObject(CGME.CGObject cgobj){
			CGME_Card = (CGME.Card) cgobj;
		}*/
				
		
		//public string Name {get{return CGME_Card.Name;}set{CGME_Card.Name = value;}}
		//public int Id {get{return CGME_Card.Id;}}
		
		public override void Write(){
			if (CGME_card != null){
				node.type_string = CGME_Card.GetType().ToString();
				node.data = CGME_Card.Write();
			}
			
		}
		
		public override void Read(){
			
			if (node != null){
				CGME_Card = new CGME.Card();
				CGME_Card.Read(node.data);
			}
			
		}
		
		protected override void CleanUp(){
			if (CGME_Card.Cleanup() == true){
				CGME_Card = null;
				Destroy(gameObject);
			}		
		}
	}
}

