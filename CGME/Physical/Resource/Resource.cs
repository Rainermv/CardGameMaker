
using System;
namespace CGME
{
	
	//[Serializable]
	public abstract class Resource : CGME.CGObject
	{
		public Resource(){

		}
		public Resource(string name){
			CGType = name;
			enabled = false;
		}
		
		public override CGObject FindObject(string name){
			return (this.CGType == name? this:null);
		}
		
		public override CGObject FindObject(int id){
			return (this.Id == id? this:null);
		}
		
		public override void Start(){
			SetId ();
		}
		
		
		
//		public abstract byte[] ToBytes();
//		public abstract void Read(byte[] FromBytes);
	}

}

