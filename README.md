[Bing Rest Client](http://github.com/AdvancedREI/Bing.RestClient)
=================

Bing.RestClient is a Portable Class Library that makes it easy to leverage Bing services from any kind of modern application.

Currently handling Bing Maps and Bing Spatial APIs, this library will eventially be able to leverage Bing's entire public API surface.

Works on .NET 4.5, Windows Phone 8, and Windows 8.x, as well as Android and iOS through Mono.

Quick start
-----------

Install the NuGet package: `Install-Package Bing.RestClient -Pre`, clone the repo, `git clone git://github.com/advancedrei/Bing.RestClient.git`, or [download the latest release](https://github.com/advancedrei/Binf.RestClient/zipball/master).

```csharp
// Take advantage of built-in Point of Interest groups
var list = PoiEntityGroups.Government();
list.Add(PoiEntityTypes.Bank);

// Build your filter list from the group.
var filter = PoiEntityGroups.BuildFilter(list);

var client = new SpatialDataClient("YOUR BING KEY HERE");

// All Bing results are in Kilometers, but convert them to Miles with our built-in conversion helper.
var results = await client.Find<PointOfInterest>("NorthAmericaPOI", "1 Microsoft Way, Redmond, WA",
    client.ConvertMiToKm(3), filter, top: 100);
```

For more information, check out our [online documentation at NuDoq](http://www.nudoq.org/#!/Projects/Bing.RestClient).

Bug tracker
-----------

Have a bug? Please create an issue here on GitHub that conforms with [necolas's guidelines](https://github.com/necolas/issue-guidelines).

https://github.com/AdvancedREI/Bing.RestClient/issues



Twitter account
---------------

Keep up to date on announcements and more by following AdvancedREI on Twitter, [@AdvancedREI](http://twitter.com/AdvancedREI).



Blog
----

Read more detailed announcements, discussions, and more on [The AdvancedREI Dev Blog](http://advancedrei.com/blogs/development).


Author
-------

**Robert McLaws**

+ http://twitter.com/robertmclaws
+ http://github.com/advancedrei


Copyright and license
---------------------

Copyright 2013 AdvancedREI, LLC.

The MIT License (MIT)

Copyright (c) 2013 AdvancedREI, LLC. and Robert McLaws

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

- The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

- You may not use this software to sell apps in the [Windows Phone Store](http://www.windowsphone.com/en-US/store/publishers?publisherId=AdvancedREI%252c%2BLLC.&appId=42268b66-a8ed-46ea-9355-1287522a7cf9) or Windows Store that replicate functionality from apps distributed by AdvancedREI.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.