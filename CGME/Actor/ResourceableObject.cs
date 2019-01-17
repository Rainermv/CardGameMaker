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
using System.Collections.Generic;

namespace CGME
{
	public abstract class ResourceableObject : CGObject
	{
		//private static int ID_SETTER;
		
		private List<CGME.Resource> resources = new List<CGME.Resource>();
		
		public override void Destroy(){
			base.Destroy ();
			
			foreach (Resource res in resources){
				res.Destroy ();
			}
			
		}
				
		// GET/SET FUNCTIONS ----------------------------------------
		
		public List<Resource> Resources{
			get{return resources;}
		}
		
		public Resource GetResource(string name){
			
			foreach (Resource resource in resources) {
				if (resource.CGType == name)
					return resource;
			}
			
			return null;
		}
		
		public Resource GetResource(int index){
			return resources[index];
		}
		
		public int Resources_Size{
			get{return resources.Count;}
		}
		
		// RESOURCES FUNCTIONS ----------------------------------------
		
		public void AddResource(CGME.Resource new_resource){
			DispatchEvent(EngineEvent.AddResource, new_resource, null);
			new_resource.Parent = this;
			resources.Add(new_resource);
		}
		
		public void RemoveResource(int index){
			resources.RemoveAt(index);
		}
		
		public void RemoveResource(CGME.Resource resource){
			resources.Remove(resource);
		}
		
		public void ClearResources(){
			resources.Clear();
		}
		
		public void EnableResources(bool enable){
			foreach (Resource res in resources){
				res.Enable(enable);
			}
		}	
		
		public CGObject FindResource(string name){
			foreach (CGObject resource in resources){
				CGObject found = resource.FindObject (name);
				if (found != null)	return found;
			}
			return null	;	
		}
		
		public CGObject FindResource(int id){
			foreach (CGObject resource in resources){
				CGObject found = resource.FindObject (id);
				if (found != null)	return found;
			}
			return null	;	
		}
		
		public void StartResources(){
			foreach (CGObject res in resources) res.Start ();
		}
		
		
	}
}

