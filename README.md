# S.M.A.R.T. API for .NET

![](Preview/App.png)

S.M.A.R.T. API is a simple and educative project to illustrate how to retrieve S.M.A.R.T. information from a hard drive using managed code in .NET. The source-code is written in VB.NET.

The source-code is fully reusable, personalizable and scalable, you can copy it and paste on your own works.

# Limitations

This tool does not pretend to be a professional S.M.A.R.T. information tool. 

Because the representation of the vendor-specific RAW values always needs further investigation, this tools has what we could consider a limitation in the meaning of being incapable to determine when a vendor-specific RAW value should be represented as a 64, 48 or 32 bit integer, because that is work of the developer itself. This is normal and understandable, because as I mentioned, this application does not pretend to be a professional tool.

For the reason being said, my implementation tries to facilitate this task by providing properties to show the RAW value in different representations. 

Anyways, almost all the vendor-specific RAW values are 32-bit integer values, which is the default kind of value represented in the user-interface of this tool.

# **Donations**

##### Through Paypal:
If you like my work and want to support it, then please consider to deposit a donation through **Paypal** by clicking on the next button:

[![Donation Account](Images/Paypal.png)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E4RQEV6YF5NZY)

[![Donation Amount](https://img.shields.io/badge/Current%20donations-0%24-red.svg)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E4RQEV6YF5NZY)

You are free to specify whatever amount of money you wish. That money will be sent to my **Paypal** account.

##### Through Envato:
If you are a .NET programmer, then maybe you would like to consider the purchase of 
'**DevCase for .NET Framework**', a powerful set of APIs for .NET developers, created by me. 

You can click the next button to go to the product specifications and the purchase page:

[![DevCase for .NET Framework](Images/DevCase%20Banner.png)](https://codecanyon.net/item/elektrokit-class-library-for-net/19260282)

Note that any source-code within the namespace 'DevCase' included in this **GitHub** repository, was freely extracted and distributed from the commercial library '**DevCase for .NET Framework**'.

<u>**Thanks in advance for your consideration!**</u> :thumbsup:

# Screenshots:

![](Preview/Screenshot%201.png)

![](Preview/Screenshot%202.png)

# Credits

Credits to people who indirectly helped me to develop this tool:

"TheLegendaryCopyCoder" for illustrating how to retrieve all the related S.M.A.R.T. data through WMI:

 - https://stackoverflow.com/a/14894138/1248295
 - http://www.know24.net/blog/C+WMI+HDD+SMART+Information.aspx

Reza Aghaei's and Simon Mourier's answers, that solved me a problem to build the visual representation in the way I wanted to in the PropertyGrid's collection editor UI:

 - https://stackoverflow.com/a/53890224/1248295
 - https://stackoverflow.com/a/53877310/1248295
