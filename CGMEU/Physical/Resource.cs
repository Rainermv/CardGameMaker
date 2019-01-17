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
	public enum ResourceType{ Number, Text, Bool, Action}
	
	[Serializable]
	//[ExecuteInEditMode]
	public class Resource : MonoBehaviour, ISerializationCallbackReceiver, CGME.IEngineListener
	{
		public int ID;
		
		//[UnityEngine.SerializeField]
		private CGME.Resource CGME_resource;// = new CGME.ResourceNumber();
				
		[UnityEngine.SerializeField]
		private SerialNode node = new SerialNode();
		
		//[UnityEngine.SerializeField]
		private ResourceView view = new ResourceView();
		
		public InterfaceEvent Trigger;
		
		public bool RestrictParent;
		public string ParentType;
					
		void Awake(){


		}
		
		void Start(){
		
			if (CGME_resource is CGME.ResourceAction){
				
				CGME.ResourceAction resource_action = (CGME.ResourceAction)CGME_resource;
				resource_action.Value = new CGME.ActionGroup();
				
				//CGME.Action action = FindObjectOfType<GameManager>().GetChildrenActions()[resource_action.ActionIndex].CGME_ActionRoot;
				CGME.Action action = FindObjectOfType<GameManager>().Actions[resource_action.ActionIndex].CGME_ActionRoot;
				
				//Debug.Log ("Getting " + action.CGType + " index is " + resource_action.ActionIndex);
				
				resource_action.Value.CopyFrom (action);
;
			}
		
			CGME_resource.AddListener(this);

		}
		
		
		public void Update(){
		
			if (view != null)
				view.Update();
		}
		
		
		public void OnBeforeSerialize()
		{
			if (CGME_resource == null) return;
			if (node == null) node = new SerialNode();
			
			node.data = CGME_resource.Write();
			node.type_string = CGME_resource.GetType().FullName;
		}
		
		public void OnAfterDeserialize()
		{
			if (node == null || CGME_resource != null) return;
			
			CGME.Resource new_res = null;
			new_res = CGME.CGFactory.CreateCGInstance(node.type_string) as CGME.Resource;
			
			if (new_res != null){
				CGME_resource = new_res;
				CGME_resource.Read(node.data);
			}
			
			
			new_res = null;
	
		}
		
		void OnEnable(){
	
			ResourceType type = Resource_type;
			
			if (view == null){
				Debug.LogWarning("ResourceView is null in On enable function");
				
			}
			else{
				view.InitAsText(gameObject,CGME_resource,Resource_type);
				//Debug.Log("Onenable - init as text");
			
			}
		
		
		}

		public ResourceType Resource_type{
			get{return GetResourceType ();}
		}

		
//		public Resource(){
//			if (CGME_resource == null)CGME_resource = new CGME.ResourceNumber();
//			
//			//Resource_type = 
//		}
		
		public void SetObject(CGME.CGObject cgobj){
		
			CGME_resource = (CGME.Resource)cgobj;
		}
		
		public CGME.Resource CGME_Resource {
			get{return CGME_resource;}
			set{CGME_resource = value;}
		}
		
		private ResourceType GetResourceType(){
			if (CGME_Resource is CGME.ResourceNumber){
				return ResourceType.Number;
			}
			else if (CGME_Resource is CGME.ResourceText){
				return ResourceType.Text;
			}
			else if (CGME_Resource is CGME.ResourceBool){
				return ResourceType.Bool;
			}
			else if (CGME_Resource is CGME.ResourceAction){
				return ResourceType.Action;
			}
			
			return ResourceType.Number;
		}
		
		void CGME.IEngineListener.Act(CGME.EngineEvent ee, CGME.CGObject source, CGME.CGObject param1, CGME.CGObject param2){
			switch (ee){
			case CGME.EngineEvent.SetId: 
				ID = param1.Id;
				break;
			case CGME.EngineEvent.ModifyResource: 
				view.Update();
				break;
				
			}
		}
		
		public void CopyFrom(CGME.Resource[] res_array){
		
			foreach (CGME.Resource resource in res_array){
				if (CopyFrom(resource) == true)
					return;
			}
			
		}
		
		public bool CopyFrom(CGME.Resource res){
			if (CGME_resource.CGType == res.CGType){
				
				if (res is CGME.ResourceNumber)						
					(CGME_resource as CGME.ResourceNumber).Value =
						(res as CGME.ResourceNumber).Value;
				
				if (res is CGME.ResourceText)						
					(CGME_resource as CGME.ResourceText).Value =
						(res as CGME.ResourceText).Value;
				
				if (res is CGME.ResourceBool)						
					(CGME_resource as CGME.ResourceBool).Value =
						(res as CGME.ResourceBool).Value;
				
				if (res is CGME.ResourceAction){						
					(CGME_resource as CGME.ResourceAction).Value =
						(res as CGME.ResourceAction).Value;
					Trigger = InterfaceEvent.Any;
					(CGME_resource as CGME.ResourceAction).Phase =
						(res as CGME.ResourceAction).Phase;
				}
				
				return true;
			
			}
			
			return false;
		}
	
	//--- EOF
	}
}
