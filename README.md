# SendMessageUsingAWSSNS

Before running this application, you must have an aws root account and follow these steps:

1-AWS Console Home -> Services -> IAM
2-Groups -> Create New Group
3-Group Name + Attach Policy(AmazonSNSFullAccess,AmazonSNSReadOnlyAccess,AmazonSNSRole) -> Create Group
4-Users -> Add User
5-User Name + Access Type(Programmatic Access Enabled) -> Next:Permissions
6-Add user to group that you have created by checking box, then next and next
7-Now you have Access Key ID and Secret Access Key.
