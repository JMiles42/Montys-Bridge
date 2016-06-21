using UnityEngine;
using System;
///		Returns the instance of this singleton.
///		Modifided Code originaly tip number 29 from:
///		http://devmag.org.za/2012/07/12/50-tips-for-working-with-unity-best-practices/
///		I don't understand all the logic behind it but it only allows one script of this type to exist
///		Making talking between scripts simple
namespace JMiles42
{
	[Serializable]
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T instance;
		public static T Instance
		{
			get
			{
				if ( !instance )
				{
					instance = ( T ) FindObjectOfType (typeof (T));
					if ( !instance )
					{
						Debug.LogError (typeof (T) + " is needed in the scene.");//Print error
					}
				}
				return instance;
			}
		}
	}
}
