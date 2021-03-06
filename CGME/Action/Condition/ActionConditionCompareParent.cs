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
	public class ActionConditionCompareParent : ActionConditionComparable
	{
		private BinaryComparison argument;
		public BinaryComparison Argument{
			get {return argument;}
			set {argument = value;}
		}
		
		public ActionConditionCompareParent () : base("Compare Parent")
		{
//			Objects[0] = SelectionSource.Original;
//			Objects[1] = SelectionSource.Original;
//			ObjectStrings[0] = "object type";
//			ObjectStrings[1] = "object type";
			
			argument = BinaryComparison.Equal;
		}
		
		private string GetParentType(int index, CGObject s, Actor p1, Actor p2){
		
			Actor actor = null;
	
			
			actor = GetActor(index,s,p1,p2);
			
			if (actor == null) return null;
			if (actor.Parent == null){
			
				Log.Warning(this,"" + actor.CGType + ": Parent invalid");
				return null;
			}
			
			return actor.Parent.CGType;

		}
		
		public override bool Effect (CGObject s, Actor p1, Actor p2)
		{	
			string[] actor_types = new string[2];
			//string actor_type_2 = null;
	
			if (Objects[0] != SelectionSource.Type)	
				actor_types[0] = GetParentType(0,s,p1,p2);
			else actor_types[0] = ObjectStrings[0];
			
			if (Objects[1] != SelectionSource.Type)	
				actor_types[1] = GetParentType(1,s,p1,p2);
			else actor_types[1] = ObjectStrings[1];
						
			switch (argument){
				case BinaryComparison.Equal: 
					return (actor_types[0] == actor_types[1]);
				case BinaryComparison.NotEqual: 
					return (actor_types[0] != actor_types[1]);
			} 

			return false;
			
		}
		
		public Actor GetParent(Actor obj){
			
			if (obj.Parent == null){
				Log.Warning(this, "Object parent invalid");
				return null;
			}
			
			return obj.Parent as Actor;
			
		}
		
		
			
		public override void SaveParameters(System.IO.BinaryWriter writer){
			base.SaveParameters(writer);
			
			writer.Write((Int32)argument);
		}	
		
		public override void LoadParameters(System.IO.BinaryReader reader){
			base.LoadParameters(reader);
			
			argument = (BinaryComparison)reader.ReadInt32();
		}
		
		public override void CopyFrom(Action copy){
			base.CopyFrom(copy);
			
			argument = (copy as ActionConditionCompareParent).argument;			
		}
	}
}

