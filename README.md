
# API documentation
[Settle Api documentation](https://developer.settle.eu/docs/settleapis/ZG9jOjgzNTg1Mg-welcome-to-the-settle-api-docs)

# Business account setup
[How to set up a business account](https://developer.settle.eu/docs/settleapis/ZG9jOjM0ODE0NTc0-set-up-a-business-account#1-the-settle-business-portal)

# API Authentication
For merchant API you need to create a merchant profile.

Once you have signed up in Settle environment you need to create API Credentials.
1.  In the menu on the left click Integration and then Add key.
2.  In the pop-up window, give this key a name (for example ‘Test key’) and choose "**USE SECRET**".
3.  Then copy Shared secret key. Secret can only be viewed once. Make sure to store it somewhere safe.

Your API Credentials are below in "Headers" section: X-Settle-Userx-Settle-Merchant and Shared secret key above

# Service Endpoints
Sandbox: https://api.sandbox.settle.eu `SettleApi.Enums.ApiMode.sandbox` <br />
Production: https://api.settle.eu `SettleApi.Enums.ApiMode.prod` 

# Source code setup
1. Clone SettleApi from [Settle_GitHub](https://github.com/nikolaiweselinow/SettleApi/) inside your project directory
2. Add the SettleApi project to your solution
3. Add a reference to the SettleApi project

# Settle API client docs
### Normal usage
SettleApiClient _apiClient = new SettleApi.SettleApiClient(MerchantId, UserId, SecretKey, SettleApi.Enums.ApiMode.sandbox);

### AuthorizationApiClient
- `Authorize(string userId)` Retrieves one of your accounts by UserID
### PaymentRequests

- `CreatePayment(PaymentRequest req)` Creates a new payment request.
- `OutcomePayment(string transactionId)` Get outcome of sent payment
- `CapturePayment(string transactionId)` Capture authozired payment
- `AbortPayment(string transactionId)` Abort payment request 
- `RefundPayment(string transactionId)` Refund captured payment 
- `GetTransactions()` Retrieves transactions

### StatusCodes
- `ListStatusCodes()` List status code
- `GetStatusCode(string statusCodeId)` Get details about a specific code


### NLog Setup (Flexible & free open-source logging for .NET)

 -  SettleApi will create a text file called **settleApiLog.txt** in the base directory of your app and it will write all message that have a minimum level of Info (basically everything) to it. 
 - If you want you can have multiple targets and rules working at the same time. Look in **NLog.config** file.
 - For more info: [Configure NLog](https://github.com/nlog/nlog/wiki/Tutorial#Configure-NLog-Targets-for-output)
