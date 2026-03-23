using slotlib.Models;

namespace team7slottetfrontend.Services;

public class AuthService
{


    public AuthService()
    {

    }

    //public async Task<List<User>> GetShiftPersonel()
    //{
    //    return await _http.GetFromJsonAsync<List<User>>("api/shift/users");
    //}

    public bool Verify(int userId, string password)
    {
        return true;
        //var response = await _http.PostAsJsonAsync("api/auth/verify", new { userId, password });
        //return response.IsSuccessStatusCode;
    }
}





