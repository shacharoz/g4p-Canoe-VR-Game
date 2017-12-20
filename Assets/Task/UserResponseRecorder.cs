using System.Collections.Generic;

public class UserResponseRecorder {


	private List<UserResponse> responses;



	public UserResponseRecorder() {
		responses = new List<UserResponse> ();
	}

	public void AddResponse(float startTime, float endTime) {
		UserResponse ur = new UserResponse ();
		ur.startTime = startTime;
		ur.endTime = endTime;

		responses.Add (ur);

	}


	public List<UserResponse> GetAllResponses(){
		return responses;
	}
}


[System.Serializable]
public class UserResponse {
	public float startTime;
	public float endTime;
	public float duration;
}