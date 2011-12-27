The Mailer Suite
=============
By Tom Harvey - [@tombuildsstuff](http://twitter.com/tombuildsstuff) - [ibuildstuff.co.uk](http://ibuildstuff.co.uk)

The Mailer Suite is a set of applications used to send personalised messages to your contacts.

Connecting into your Google Contacts account, it's possible to send a personalised birthday/happy new years message to your contacts.

Texts are currently sent using Clickatell ([pricing available here](http://www.clickatell.com/pricing/message_cost.php)) - but this can easily be swapped out to use other providers.

How To Use
-------

Mailer can automatically send messages using the details available in your Google Contacts account.

You'll need to make a little change to each contact, so that we can determine the Gender.

What you need to do is create a new "Website" field, with the Key "Gender", and then set 'Male' or 'Female' (or simply M/F) as needed.

Unfortunately the Google-provided library didn't return these Custom Fields in my testing (or I'd have made use of them) - if you've got solution there's an issue for it (above).


Set Up
-------
*  Open up the [AppName].config in a text editor
*  Set your Google Credentials in the 'GoogleUsername' and 'GooglePassword' fields
*  Set your Message in the 'MaleTextMessage' and 'FemaleTextMessage' fields
*  Set the Groups that you want to send too in the 'GroupsToMessage' field
*  Set your [Clickatell](http://www.clickatell.com) Credentials in the fields prefixed-'ClickATell'


Custom Sender Name
-------
When using ClickATell as a provider, you need to request your "Sender/From" name (this is to prevent abuse).
Once you've logged in - you can manage your Custom Senders here: https://www.clickatell.com/central/central/dashboard/senderid_dashboard.php
Once approved by ClickATell (normally within 24 hours) - you can make use it.


Your mobile number should automatically be available once you sign up; so you should only need to do this if you'd like a custom sender name i.e. 'Miss Piggy'


To Do
-------

See here: [Issues](http://github.com/tombuildsstuff/Mailer/issues)

License
-------
See here: [http://tombuildsstuff.mit-license.org/](http://tombuildsstuff.mit-license.org/)