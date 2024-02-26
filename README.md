<!-- Common Project Tags:
command-line 
console-applications 
desktop-app 
desktop-application 
dotnet 
dotnet-core 
netcore 
netframework 
netframework48 
tool 
tools 
vbnet 
visualstudio 
windows 
windows-app 
windows-application 
windows-applications 
windows-forms 
winforms 
 -->

# S.M.A.R.T. API for .NET developers

### An S.M.A.R.T. drive information API for .NET developers

![App](Images/App.png)

------------------

## 👋 Introduction

S.M.A.R.T. API is a class library (dll file) that illustrates how to retrieve S.M.A.R.T. information from a disk drive using managed code. 

The source-code is written in VB.NET, and targets .NET Framework 4.8. The source-code is fully reusable, personalizable and scalable, you can copy it and paste on your own works.

The source-code comes with a demonstration through a desktop application that shows the S.M.A.R.T. info of your drives.

## 🖼️ Screenshots

![](Images/Screenshot%201.png)

![](Images/Screenshot%202.png)

## 📝 Requirements

- Microsoft Windows OS.

## 🤖 Getting Started

Download the latest release by clicking [here](https://github.com/ElektroStudios/S.M.A.R.T.-API-for-.NET-developers-SMART-drive-info/releases/latest),

## ‼️ Limitations

This tool does not pretend to be a professional S.M.A.R.T. tool software. 

Because the representation of the vendor-specific RAW values always needs further investigation, this tool has what we could consider a limitation in the meaning of being incapable to determine when a vendor-specific RAW value should be represented as a 64, 48 or 32 bit integer, because that is work of the developer itself. This is normal and understandable, because as I mentioned, this application does not pretend to be a professional tool.

For the reason being said, my implementation tries to facilitate this task by providing properties to show the RAW value in different representations. 

Anyway, almost all the vendor-specific RAW values are 32-bit integer values, which is the default kind of value represented in the user-interface of this tool.

## 🔄 Change Log

Explore the complete list of changes, bug fixes, and improvements across different releases by clicking [here](/Docs/CHANGELOG.md).

## 🏆 Credits

@TheLegendaryCopyCoder for illustrating how to retrieve all the related S.M.A.R.T. data through WMI:

 - https://stackoverflow.com/a/14894138/1248295
 - http://www.know24.net/blog/C+WMI+HDD+SMART+Information.aspx

## ⚠️ Disclaimer:

This Work (the repository and the content provided in) is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the Work or the use or other dealings in the Work.

## 💪 Contributing

Your contribution is highly appreciated!. If you have any ideas, suggestions, or encounter issues, feel free to open an issue by clicking [here](https://github.com/ElektroStudios/S.M.A.R.T.-API-for-.NET-developers-SMART-drive-info/issues/new/choose). 

Your input helps make this Work better for everyone. Thank you for your support! 🚀

## 💰 Beyond Contribution 

This work is distributed for educational purposes and without any profit motive. However, if you find value in my efforts and wish to support and motivate my ongoing work, you may consider contributing financially through the following options:

<br></br>
<p align="center"><img src="/Images/github_circle.png" height=100></p>
<p align="center">__________________</p>
<h3 align="center">Becoming my sponsor on Github:</h3>
<p align="center">You can show me your support by clicking <a href="https://github.com/sponsors/ElektroStudios/">here</a>, <br align="center">contributing any amount you prefer, and unlocking rewards!</br></p>
<br></br>

<p align="center"><img src="/Images/paypal_circle.png" height=100></p>
<p align="center">__________________</p>
<h3 align="center">Making a Paypal Donation:</h3>
<p align="center">You can donate to me any amount you like via Paypal by clicking <a href="https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=E4RQEV6YF5NZY">here</a>.</p>
<br></br>

<p align="center"><img src="/Images/envato_circle.png" height=100></p>
<p align="center">__________________</p>
<h3 align="center">Purchasing software of mine at Envato's Codecanyon marketplace:</h3>
<p align="center">If you are a .NET developer, you may want to explore '<b>DevCase Class Library for .NET</b>', <br align="center">a huge set of APIs that I have on sale. Check out the product by clicking <a href="https://codecanyon.net/item/elektrokit-class-library-for-net/19260282">here</a></br><br align="center"><i>It also contains all piece of reusable code that you can find across the source code of my open source works.</i></p>
<br></br>

<h2 align="center"><u>Your support means the world to me! Thank you for considering it!</u> 👍</h2>
