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
	public class ResourceBool : CGME.Resource
	{
		private bool _value;
		
		public ResourceBool(){
			cgtype = "Name";
			Value = true;
		}
//		public ResourceBool(string name, bool value, bool enabled = true){
//			
//			this.Name = name;
//			SetValue(value);
//			this.enabled = enabled;
//		}
		
		public bool Value{
			get{return _value;}
			set{_value = value;}
		}
		
		public override void Enable (bool enable)
		{
			this.enabled = enable;
		}
		
		public override string ToString(){
			return (cgtype + ": " + Value.ToString());
		}
		
		public void SwitchValue(bool value){
			_value = !Value;
			DispatchEvent(EngineEvent.ModifyResource, null, null);
		}
		
		public void SetValue(bool value){
			_value = Value;
			DispatchEvent(EngineEvent.ModifyResource, null, null);
		}
		
		public override void SaveParameters(System.IO.BinaryWriter writer){
			writer.Write(_value);
			//action.Write(name);
		}
		
		public override void LoadParameters(System.IO.BinaryReader reader){
			_value = reader.ReadBoolean();
		}
		
	}
}
