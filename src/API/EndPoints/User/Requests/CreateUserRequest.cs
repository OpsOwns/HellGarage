﻿namespace API.EndPoints.User.Requests;

public record CreateUserRequest(string FirstName, string LastName, string Email, string Password, string Phone);