# Hubtel.SafeWallet


## Usage

Before you begin, ensure you have the following prerequisites installed:

- [.NET Core](https://dotnet.microsoft.com/download)

## Installation

To install SafeWallet, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/SafeWallet.git`
2. Navigate to the project directory: `cd SafeWallet`
3. Run `dotnet restore`
4. Run the application: `dotnet run`


To use SafeWallet, follow these steps:

1. Access the application through the provided API endpoints.
2. Create an account and log in.
3. Add your wallets and manage your financial information securely.


## API Endpoints

The following are the main API endpoints provided by SafeWallet:
- **POST /api/v1/account/signin:** Login into account.
- **POST /api/v1/account/signup:** Create an account.

- **POST /api/v1/wallets:** Create a new wallet.
- **DELETE /api/v1/wallets/{id}:** Remove a wallet by ID.
- **GET /api/v1/wallets/{id}:** Retrieve details of a specific wallet.
- **GET /api/v1/wallets:** Retrieve a list of all wallets.



