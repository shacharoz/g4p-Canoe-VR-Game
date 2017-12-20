using System.Collections.Generic;

public class UserResponseRecorder {


	public List<UserResponse> responses;



	public UserResponseRecorder() {


	}

}


[System.Serializable]
public class UserResponse {
	public float startTime;
	public float endTime;
	public float duration;
}