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
	
	public enum CompareOperation {Equals, Larger, Smaller, LargerOrEqual, SmallerOrEqual}
	
	public class ActionConditionCompareResource : Action
	{
		
		
		public ActionConditionCompareResource() : base("Compare Resource"){
			
			target_resource_index = 0;
			operation_resource_index = 0;
			
			bool_mod = false;
			text_mod = "text value";
			number_mod = 0;
			action_mod = "";
			
			bool_mod2 = false;
			text_mod2 = "text value";
			number_mod2 = 0;
			action_mod2 = "";
			
			target = ResourceSource.Original;
			param1 = ResourceSource.Original;
			param2 = ResourceSource.Original;
			
			operation = CompareOperation.Equals;
			
		}	
		
		// SERIALIZABLE
		private int target_resource_index;
		private int operation_resource_index;
		
		private ResourceSource target;
		private ResourceSource param1;
		private ResourceSource param2;
		
		private CompareOperation operation;
		
		private bool bool_mod;
		private string text_mod;
		private int number_mod;
		private string action_mod;
		
		private bool bool_mod2;
		private string text_mod2;
		private int number_mod2;
		private string action_mod2;
		
		public int Target_Resource{
			get{return target_resource_index;}
			set{target_resource_index = value;}
		}
		
		public int Operation_Resource{
			get{return operation_resource_index;}
			set{operation_resource_index = value;}
		}
		
		public ResourceSource Target{
			get{return target;}
			set{target = value;}
		}
		public ResourceSource Param1{
			get{return param1;}
			set{param1 = value;}
		}
		public ResourceSource Param2{
			get{return param2;}
			set{param2 = value;}
		}
		public CompareOperation Operation{
			get{return operation;}
			set{operation = value;}
		}
		
		public bool BoolMod{
			get{return bool_mod;}
			set{bool_mod = value;}
		}
		
		public string TextMod{
			get{return text_mod;}
			set{text_mod = value;}
		}
		
		public int NumberMod{
			get{return number_mod;}
			set{number_mod = value;}
		}
		
		public bool BoolMod2{
			get{return bool_mod;}
			set{bool_mod = value;}
		}
		
		public string TextMod2{
			get{return text_mod;}
			set{text_mod = value;}
		}
		
		public int NumberMod2{
			get{return number_mod;}
			set{number_mod = value;}
		}
		
		public override bool Effect (CGObject s, Actor p1, Actor p2){
			
			GameManager.DebugLog("Comparing Resources");
			GameManager.DebugLog("Source is " + s.CGType);
			GameManager.DebugLog("Parameter is " + p1.CGType);
			
			Resource target_resource = GetResourceFromParameter(target, s, p1, p2 , 0);
			Resource op1 = GetResourceFromParameter(param1, s, p1, p2, 1);
			//Resource op2 = GetResourceFromParameter(param2, s, p1, p2, 2);
			
			//	string type = target_resource.CGType;
			
			if (target_resource != null && op1 != null){
				
				if (target_resource is ResourceBool && op1 is ResourceBool)
					return CompareBool((ResourceBool)target_resource, (ResourceBool)op1, operation);
				
				if (target_resource is ResourceNumber && op1 is ResourceNumber){
					return CompareNumber((ResourceNumber)target_resource, (ResourceNumber)op1, operation);

				}
				if (target_resource is ResourceText && op1 is ResourceText)
					return CompareText((ResourceText)target_resource,(ResourceText)op1, operation);
				
			}
			
			GameManager.DebugLog("Compare Resource failed");
			
			return false;
			
		}	
		
		private bool CompareBool(ResourceBool target, ResourceBool op1, CompareOperation operation){
			
			
			switch (operation){
				
			case CompareOperation.Equals: 		
				return (target.Value == op1.Value);
			default:	
				GameManager.DebugLog("Error - operator invalid");
				break;
			}
			
			
			
			return false;
			
		}
		
		private bool CompareNumber(ResourceNumber target, ResourceNumber op1, CompareOperation operation){
			
			//GameManager.DebugLog("Comparing: " + target.Value + " " + operation + " " + op1.Value);
			//GameManager.DebugLog((target.Value >= op1.Value).ToString());
			
			switch (operation){
				
			case CompareOperation.Equals: 			return target.Value == op1.Value;
			case CompareOperation.Larger: 			return target.Value >  op1.Value;
			case CompareOperation.LargerOrEqual: 	return target.Value >= op1.Value;
			case CompareOperation.Smaller: 			return target.Value <  op1.Value;
			case CompareOperation.SmallerOrEqual: 	return target.Value <= op1.Value;
				
			}
			
			return false;
		}
		
		private bool CompareText(ResourceText target, ResourceText op1, CompareOperation operation){
			
			switch (operation){
				
			case CompareOperation.Equals: 		return target.Value == op1.Value;
			default:	
				GameManager.DebugLog("Error - operator invalid");
				break;
			}
			
			return false;
			
		}
		
		
		
		private Resource GetResourceFromParameter(ResourceSource param, CGObject s, Actor p1, Actor p2, int p){
			
			CGObject obj = null;
			CGLibrary lib = manager.Library;;
			
			string resource_type = "null";
			
			if (p == 0){
				obj = lib.GetResource(target_resource_index);
				resource_type = lib.GetResourceType(target_resource_index);
				GameManager.DebugLog("Finding on target - " + resource_type);
			}
			if (p == 1){
				obj = lib.GetResource(operation_resource_index);
				resource_type = lib.GetResourceType(operation_resource_index);
				GameManager.DebugLog("Finding on operation - " + resource_type);
			}
			
			if (obj == null || !(obj is Resource)){
				GameManager.DebugLog("Error - " + resource_type + " not found in library");
				return null;
			} 
			
			Resource res = obj as Resource;
			
			switch (param){
			case ResourceSource.FixedValue: return GetByFixedValue(res, p);
			case ResourceSource.Selected: return GetBySelected(res, p1, resource_type);
			case ResourceSource.Original: return GetBySource(res, s, resource_type); 
			}
			
			return null;
			
		}
		
		private Resource GetBySelected(Resource res, Actor p1, string resource_type){
			
			//string type = res.CGType;
			
			CGObject obj = p1.FindResource(resource_type);
			
			if (obj == null || !(obj is Resource)){
				GameManager.DebugLog("Error (selected) - " + res.CGType + " not found in " + p1.CGType);
				return null;
				
			}
			
			return obj as Resource;
			
		}
		
		private Resource GetBySource(Resource res, CGObject s, string resource_type){
			
			//string type = res.CGType;
			
			if (s is Actor){
				CGObject obj = (s as Actor).FindResource(resource_type);
				
				if (obj != null && (obj is Resource)) return obj as Resource;
				
				GameManager.DebugLog("Error (source) -" + res.CGType + " not found in " + s.CGType);
				
			}
			
			GameManager.DebugLog("Error - " + s.CGType + " is not an Actor");
			return null;
			
		}
		
		private Resource GetByFixedValue(Resource res, int p){
			bool bv = false;
			int iv = 0;
			string sv = null;
			
			if (p == 0){
				GameManager.DebugLog("Eror - Invalid fixed value on Target resource");
			}
			
			if (p == 1){
				bv = bool_mod;
				iv = number_mod;
				sv = text_mod;
			}
			
			if (p == 2){
				bv = bool_mod2;
				iv = number_mod2;
				sv = text_mod2;
			}
			
			Resource return_resource = null;	
			
			if (res is ResourceAction) {
				GameManager.DebugLog("Modifying a Resource Action is not currently supported");
				return null;
			}	
			else if (res is ResourceBool){  
				return_resource  = new ResourceBool();
				(return_resource as ResourceBool).Value = bv;
			}
			else if (res is ResourceNumber){  
				return_resource  = new ResourceNumber();
				(return_resource as ResourceNumber).Value = iv;
			}
			else if (res is ResourceText){  
				return_resource  = new ResourceText();
				(return_resource as ResourceText).Value = sv;
			}
			
			return return_resource;
			
		}
		
		public override void SaveParameters(System.IO.BinaryWriter writer){
			
			//GameManager.DebugLog("Saving Modify");
			
			base.SaveParameters(writer);
			
			writer.Write (target_resource_index);
			writer.Write (operation_resource_index);
			
			writer.Write ((Int32)target);
			writer.Write ((Int32)param1);
			writer.Write ((Int32)param2);
			
			writer.Write ((Int32)operation);
			
			writer.Write (action_mod);
			writer.Write (bool_mod);
			writer.Write (text_mod);
			writer.Write (number_mod);
			
			writer.Write (action_mod2);
			writer.Write (bool_mod2);
			writer.Write (text_mod2);
			writer.Write (number_mod2);
		}	
		
		public override void LoadParameters(System.IO.BinaryReader reader){
			
			//GameManager.DebugLog("Loading Modify");
			
			base.LoadParameters(reader);
			
			target_resource_index = reader.ReadInt32();
			operation_resource_index = reader.ReadInt32();
			
			target = (ResourceSource)reader.ReadInt32();
			param1 = (ResourceSource)reader.ReadInt32();
			param2 = (ResourceSource)reader.ReadInt32();;
			
			operation = (CompareOperation)reader.ReadInt32();
			
			action_mod = reader.ReadString();
			bool_mod = reader.ReadBoolean();
			text_mod = reader.ReadString();
			number_mod = reader.ReadInt32();
			
			action_mod2 = reader.ReadString();
			bool_mod2 = reader.ReadBoolean();
			text_mod2 = reader.ReadString();
			number_mod2 = reader.ReadInt32();
			//trigger = (CGME.InterfaceEvent)Enum.Parse(typeof(InterfaceEvent),reader.ReadString());
		}
		
		public override void CopyFrom(Action copy){
			
			base.CopyFrom(copy);
			
			target_resource_index = (copy as ActionConditionCompareResource).target_resource_index;
			operation_resource_index = (copy as ActionConditionCompareResource).operation_resource_index;
			
			target = (copy as ActionConditionCompareResource).target;
			param1 = (copy as ActionConditionCompareResource).param1;
			param2 = (copy as ActionConditionCompareResource).param2;
			
			operation = (copy as ActionConditionCompareResource).operation;
			
			action_mod = (copy as ActionConditionCompareResource).action_mod;
			bool_mod = (copy as ActionConditionCompareResource).bool_mod;
			text_mod = (copy as ActionConditionCompareResource).text_mod;
			number_mod = (copy as ActionConditionCompareResource).number_mod;
			
			action_mod2 = (copy as ActionConditionCompareResource).action_mod2;
			bool_mod2 = (copy as ActionConditionCompareResource).bool_mod2;
			text_mod2 = (copy as ActionConditionCompareResource).text_mod2;
			number_mod2 = (copy as ActionConditionCompareResource).number_mod2;
			
		}
	}
}

