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
	public enum BufferLoadType {Pop, Index};
	
	public class ActionBufferLoad : ActionGroup
	{
		
		public BufferLoadType LoadType;
		public int LoadIndex;
		
		public ActionBufferLoad (): base("Load from Buffer"){
		
			LoadType = BufferLoadType.Pop;
			LoadIndex = 0;
		}
		public override bool Effect (CGObject s, Actor p1, Actor p2)
		{
			//CGObject ob = GetFromSource(Selection, s, p1, p2);
			
			Actor act = null;
			
			switch (LoadType){
			
				case BufferLoadType.Pop:
					act = manager.CommandBufferPopSelection();
					break;
				case BufferLoadType.Index:
					act = manager.CommandBufferGetFromSelection(LoadIndex);
					break;		
			}
			
			if 	(act == null){
				Log.Warning(this,"Error loading object in buffer");
				return false;
			}
			
			
			base.Run (s,act,p2);
			
			return true;
				
			
		}
		
		public override void SaveParameters (System.IO.BinaryWriter writer)
		{
			base.SaveParameters (writer);
			
			writer.Write ((Int32)LoadType);
			writer.Write (LoadIndex);
		}
		
		public override void LoadParameters (System.IO.BinaryReader reader)
		{
			base.LoadParameters (reader);
			
			LoadType = (BufferLoadType)reader.ReadInt32();
			LoadIndex = reader.ReadInt32();
		}
		
		public override void CopyFrom (Action copy)
		{
			base.CopyFrom (copy);
			
			LoadType = (copy as ActionBufferLoad).LoadType;
			LoadIndex = (copy as ActionBufferLoad).LoadIndex;
		}
	}
}

