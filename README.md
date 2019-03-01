# Welcome to the ClearBank Developer Test Solution by S.Audley
##
## Duration Taken
Managed to spend 40 minutes doing this.
##
## Testing Frameworks Used
I decided to use Microsoft Test with Moq.
##
## Changes to Solution 
I came to the conclusion after looking at the existing code that it would need the following

- An IConfigService to manage the type of data configured. This could also be expanded for future use to contain the relevant data source connection strings
- An Account Factory that would consist of Data stores
- Each AccountData score would consist of Account 
- A IPaymentSchemeValidation interface that would handle the many rules/criteria for each payment scheme for processing payments 
##
## Testing
 I only tested the MakePaymentRequest functionality under the following conditions

1. - Invalid Account
2. - Valid Account but disabled
3. - Valid account, insufficient balance
4. - MakeFasterPayment
5. - MakeChapsPayment```

It might be worthy to note that if needed it would have been very simple to write the testscripts for the following
Insufficient Balance - Chaps Payment
Insufficient Balance - Bacs Payment
Insufficient Balance - FasterPayments
Disabled Account trying a Chaps Payment
Disabled Account trying a Bacs Payment
Disabled Account trying a FasterPayments
##
# Enjoy!
