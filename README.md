# ClearBank.DeveloperTest
Managed to spend 40 minutes doing this.
Testing Frameworks Uses I decided to use Microsoft Test with Moq.
Changes to Solution I came to the conclusion after looking at the existing code that it would need the following
An IConfigService to manage the type of data configured. This could also be expanded for furture use to contain the relevant data source connection strings
An Account Factory that would consist of Data stores
Each AccountData score would consist of Account
A IPaymentSchemeValidation interface that would handle the many rules/criteria for each payment scheme for processing payments
Testing I only tested the MakePaymentRequest functionality under the following conditions
Invalid Account
Valid Account but disabled
Valid account, insufficient balance
MakeFasterPayment
MakeChapsPayment
MakeBacsPayment
It might be worthy to note that if needed it would have been very simple to write the testscripts for the following
Insufficient Balance - Chaps Payment
Insufficient Balance - Bacs Payment
Insufficient Balance - FasterPayments
Disabled Account trying a Chaps Payment
Disabled Account trying a Bacs Payment
Disabled Account trying a FasterPayments
Enjoy!
