namespace NoAiDinner.Contracts.Authentication;

public record LoginRequest(
    string Email,
    string Password
);