Managed to spend 40 minutes doing this.

Testing Frameworks Uses
I decided to use Microsoft Test with Moq.

Changes to Solution
I came to the conclusion after looking at the existing code that it would need the following
1. An IConfigService to manage the type of data configured. This could also be expanded for furture use to contain the relevant data source connection strings
2. An Account Factory that would consist of Data stores
3. Each AccountData score would consist of Account 
4. A IPaymentSchemeValidation interface that would handle the many rules/criteria for each payment scheme for processing payments

Testing
I only tested the MakePaymentRequest functionality under the following conditions
1. Invalid Account
2. Valid Account but disabled
3. Valid account, insufficient balance
4. MakeFasterPayment
5. MakeChapsPayment
6. MakeBacsPayment

It might be worthy to note that if needed it would have been very simple to write the testscripts for the following
1. Insufficient Balance - Chaps Payment
2. Insufficient Balance - Bacs Payment
3. Insufficient Balance - FasterPayments
4. Disabled Account trying a Chaps Payment
5. Disabled Account trying a Bacs Payment
6. Disabled Account trying a FasterPayments

Enjoy!



