using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections;

public class PersonData : MonoBehaviour
{
	public InputField yob;
	public Slider gender;
	bool hasData = false;

	public void SetData()
	{
		if( hasData )
		{
			Gender gend;
			if( gender.value == 0 )
				gend = Gender.Male;
			else if( gender.value == 1 )
				gend = Gender.Female;
			else
				gend = Gender.Unknown;

			SimpleAnalitics.PersonalData(System.Int32.Parse(yob.text), gend);
		}
	}
	public void DataEdited()
	{
		hasData = true;
	}
}
