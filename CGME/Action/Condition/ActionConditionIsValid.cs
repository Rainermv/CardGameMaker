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
	
	public class ActionConditionIsValid : Action
	{
		private SelectionSource source = new SelectionSource();
		public SelectionSource Source{
			get {return source;}
			set {source = value;}
		}
		
		private string source_string;
		public string SourceString{
			get {return source_string;}
			set {source_string = value;}
		}
			
		public ActionConditionIsValid () : base("Test Validity")
		{
			source = SelectionSource.Original;
			source_string = "object type";
		}
		
		public override bool Effect (CGObject s, Actor p1, Actor p2 ){
			
			CGObject obj = null;
			
			switch (source){
				
			case SelectionSource.Original: obj = s; break ;
			case SelectionSource.Selected: obj = p1; break ;
			case SelectionSource.Type:	   obj = manager.CommandFindObject(source_string); break ;
				
			}
			
			return (obj != null);
			
		}
		
		
			
		public override void SaveParameters(System.IO.BinaryWriter writer){
			base.SaveParameters(writer);
			
			writer.Write((Int32)source);
			writer.Write (source_string);
		}	
		
		public override void LoadParameters(System.IO.BinaryReader reader){
			base.LoadParameters(reader);
			
			source = (SelectionSource)reader.ReadInt32();
			source_string = reader.ReadString();
		}
		
		public override void CopyFrom(Action copy){
			base.CopyFrom(copy);
			
			source = (copy as ActionConditionIsValid).source;		
			source_string = (copy as ActionConditionIsValid).source_string;	
		}
	}
}
