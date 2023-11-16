# A11Y.Feature.Forms

You may still not landed in the composable world? Still working with XP Solutions on MVC?

Then you will be happy with thisinitial package for the Sitecore Forms MVC Accessibility Feature.

Most of the common Sitecore Fields are made accessibility ready!

### Description

The module adds additional expanders to the Sitecore Forms backend with a list of fields which are made accessibility ready:

![Expanders](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/01.%20Expanders.png?raw=true)

Those expanders contains a bunch of fields which are fully customized to be accessibility ready:

![Basic fields](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/02.%20Basic.png?raw=true)
![List fields](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/03.%20Lists.png?raw=true)

Let's take a closer look to the fields themselves, this is where the magic happens!

First of all, there is a new field in the validation section called **"Required Field Message"**, now you can customize your validation messages for every language and the can be user friendly.

![Custom Validation messages](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/04.%20Custom%20Validation%20Messages.png?raw=true)

Second, there is a new **"Accessibility Expander"** which adds attributes to the fields to fillout form fields automatically! This is a huge help for blind people if the browser does the autocompletion by himself and the user confirms!

![Autocomplete](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/05.%20Autocomplete.png?raw=true)
![Autocomplete combined](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/06.%20Autocomplete%20combined.png?raw=true)

All this values are taken from WCAG and are available as a datasource in the package.

Third, one final addition to the fields is a new security field called **“Honeypot”** this is a spam trap. You all know use Captchas to prevent forms being submitted by a bot which is sadly a reason which could sites shut down.
There are several Captchas out there, Audio Captchas or Re-Captcha where you have to search traffic lights in 3x3 tiles, but keep in mind we’re talking about blind people or people who can’t hear. All those captchas will not work for them.

![Honeypot](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/07.%20Honeypot.png?raw=true)

Honeypot is a simple solution to prevent spam form submissions, it is just a hidden field. The technique behind is: Bots are straight forward they fill out every field in a form, also the hidden ones, what I have added is just a JavaScript to prevent that on client side **AND** also a custom submit action to prevent that on server side. If you want to use the Honeypot field, please keep in mind to use the submit action in your form as well and you will never have spam form submissions in the future anymore!

![Honeypot Submit Action](https://github.com/monkey-dsc/A11Y.Feature.Forms/blob/master/pics/08.%20Honeypot%20Submit%20Action.png?raw=true)

### Compatibility

This package was created on a Sitecore **9.2.0** but it works up to **10.3.1** *(installed on an empty 10.3.1 instance)*. 
Currently this works for default Sitecore Form fields, but in my case we used FormsExtensions as well, so if you need a **compatibility** to **FormsExtensions** please get in contact with me.

### Installation

The installation is quite simple, it's just a Sitecore package which comes with all necessary core an master items, as well as all needed files.

> ==**But, be careful! There are several items which could get in conflict with your local environment!**==

All *"new"** Expanders or fields are separated into a folder called "A11Y". But in Sitecore Forms there are Action items and Operators where you need to explicitely add fields to work with conditions.

In the package those items are marked with the option *"ask user"*, so please **review** them, if you have already created custom form fields!

The following items are affected:

#### Action Items
> /sitecore/system/Settings/Forms/Meta Data/Conditions/Action Types

1. **show**
2. **hide**
3. **enable**
4. **disable**

Review all those action items that your custom fields, FormsExtension fields and the A11Y fields are added to the **"Allowed Field Types"**!

#### Operators
> /sitecore/system/Settings/Forms/Meta Data/Conditions/Operators

Operators are bit more difficult, because you don't need every field in every operator. Again, **review** you custom fields here!
My suggestion is as follows:

1. **is equal to**
   - All A11Y fields
2. **is not equal to**
   - All A11Y fields
3. **contains**
   - Single-Line Text (A11Y)
   - Multi-Line Text (A11Y)
   - Email (A11Y)
   - Telephone (A11Y)
4. **does not contain**
   - Single-Line Text (A11Y)
   - Multi-Line Text (A11Y)
   - Email (A11Y)
   - Telephone (A11Y)
5. **starts with**
   - Single-Line Text (A11Y)
   - Multi-Line Text (A11Y)
   - Email (A11Y)
   - Telephone (A11Y)
6. **does not start with**
   - Single-Line Text (A11Y)
   - Multi-Line Text (A11Y)
   - Email (A11Y)
   - Telephone (A11Y)
7. **ends with**
   - Single-Line Text (A11Y)
   - Multi-Line Text (A11Y)
   - Email (A11Y)
   - Telephone (A11Y)
8. **does not end with**
   - Single-Line Text (A11Y)
   - Multi-Line Text (A11Y)
   - Email (A11Y)
   - Telephone (A11Y)
9. **is greater than**
   - Number (A11Y)
   - Date (A11Y)
10. **is greater than or equal to**
    - Number (A11Y)
    - Date (A11Y)
11. **is less than**
    - Number (A11Y)
    - Date (A11Y)
12. **is less than or equal to**
    - Number (A11Y)
    - Date (A11Y)

