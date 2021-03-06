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

namespace CGME
{
	//[Serializable]
	public class Player : CGME.Actor
	{
		public List<CGME.Deck> decks = new List<CGME.Deck>();

		// CONSTRUCTORS ------------------------------------------
		public Player(){
			cgtype = "New Player";
			enabled = true;
		}

//		public Player(string name, bool enabled = true){
//			Name = name;
//			this.enabled  = enabled;
//		}

		// GET/SET FUNCTIONS -----------------------------
		
		public Deck GetDeck(CGME.Deck _deck){
			
			foreach (Deck deck in decks) {
				if (deck == _deck)
					return deck;
			}
			
			return null;
		}
		
		public Deck GetDeck(string name){
			foreach (Deck deck in decks) {
				if (deck.CGType == name)
					return deck;
			}
			
			return null;
		}

		public Deck GetDeck(int index){
			return decks[index];
		}

		public int Decks_Size{
			get { return decks.Count;}
		}
		
		
		// LIST FUNCTIONS ----------------------------------------
		
		public override CGObject AddChild(CGObject child){
			if (child is Deck){
				child.Parent = this;
				return AddDeck (child as Deck);
			}
			
			return null;
		}
		
		public override void RemoveChild(CGObject child){
			if (child is Deck)
				RemoveDeck (child as Deck);
		}
		
		public Deck AddDeck(CGME.Deck new_deck){
			DispatchEvent(EngineEvent.AddChild, new_deck, null);
			decks.Add(new_deck);
			
			new_deck.Parent = this;
			
			return new_deck;
		}
		
		public Deck AddDeck(string name){
			Deck deck = new Deck();
			DispatchEvent(EngineEvent.AddChild, deck, null);
			decks.Add(deck);
			deck.Parent = this;
			return deck;
		}
		
		public void RemoveDeck(CGME.Deck deck){
			decks.Remove(deck);
		}

		public void RemoveDeck(int index){
			decks.RemoveAt(index);
		}
		
		public void ClearDecks(){
			decks.Clear();
		}
		
		// PUBLIC FUNCTIONS --------------------------------------
		
		public override void  EnableChildren(bool enable){
						
			foreach (Deck deck in decks){
				deck.Enable(enable);
			}
		}
		
		public override CGObject FindChildren(string name){
			
			foreach (CGObject child in decks){
				CGObject found = child.FindObject(name);
				if (found != null) return found;
				
			}
			return null;
		}
		
		public override CGObject FindChildren(int id){
			
			foreach (CGObject child in decks){
				CGObject found = child.FindObject(id);
				if (found != null) return found;
				
			}
			return null;
		}
		
		public override void StartChildren(){
			foreach (CGObject child in decks)
				child.Start();
		}
		
		public override void ClearChildren(){
			decks.Clear();
		}
		public override void CleanupChildren(){
			for (int i = 0; i < decks.Count; i++){
				if (decks[i].DestroyFlag){
					decks.RemoveAt(i);
					break;
				}
			}
		}


	}
}


