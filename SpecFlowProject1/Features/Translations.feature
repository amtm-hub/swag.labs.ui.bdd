﻿Feature: Translations
	As a user, I would like to be able to switch to a different language when going to the Facebook site

@mytag
Scenario: Susie views the available languages
	Given Susie is on login screen for "Facebook"
	When she views the list of available languages
	Then the Select Your Language modal is displayed with a list of languages
		"""
		All Languages
		Africa and Middle East
		Americas
		Asia-Pacific
		Eastern Europe
		Western Europe
		Af-Soomaali
		Afrikaans
		Azərbaycan dili
		Bahasa Indonesia
		Bahasa Melayu
		Basa Jawa
		Bisaya
		Bosanski
		Brezhoneg
		Català
		Corsu
		Cymraeg
		Dansk
		Deutsch
		Eesti
		English (UK)
		English (US)
		Español
		Español (España)
		Euskara
		Filipino
		Français (Canada)
		Français (France)
		Frysk
		Fula
		Føroyskt
		Gaeilge
		Galego
		Guarani
		Hausa
		Hrvatski
		Ikinyarwanda
		Italiano
		Iñupiatun
		Kiswahili
		Kreyòl Ayisyen
		Kurdî (Kurmancî)
		Latviešu
		Lietuvių
		Magyar
		Malagasy
		Malti
		Nederlands
		Nederlands (België)
		Norsk (bokmål)
		Norsk (nynorsk)
		O'zbek
		Polski
		Português (Brasil)
		Português (Portugal)
		Română
		Sardu
		Shona
		Shqip
		Slovenčina
		Slovenščina
		Suomi
		Svenska
		Tiếng Việt
		Türkçe
		Zaza
		Íslenska
		Čeština
		ślōnskŏ gŏdka
		Ελληνικά
		Беларуская
		Български
		Македонски
		Монгол
		Русский
		Српски
		Татарча
		Тоҷикӣ
		Українська
		кыргызча
		Қазақша
		Հայերեն
		עברית
		اردو
		العربية
		فارسی
		پښتو
		کوردیی ناوەندی
		ܣܘܪܝܝܐ
		नेपाली
		मराठी
		हिन्दी
		অসমীয়া
		বাংলা
		ਪੰਜਾਬੀ
		ગુજરાતી
		ଓଡ଼ିଆ
		தமிழ்
		తెలుగు
		ಕನ್ನಡ
		മലയാളം
		සිංහල
		ภาษาไทย
		ພາສາລາວ
		မြန်မာဘာသာ
		ქართული
		አማርኛ
		ភាសាខ្មែរ
		ⵜⴰⵎⴰⵣⵉⵖⵜ
		中文(台灣)
		中文(简体)
		中文(香港)
		日本語
		日本語(関西)
		한국어
		"""

@mytag
Scenario: Susie switches to a different language
	Given Susie is on login screen for "Facebook"
	When she switches to "Filipino" language
	Then the language on the login screen is translated
		|                 | values                    |
		| login           | Mag-log In                |
		| forgot password | Nakalimutan ang Password? |
		| create account  | Gumawa ng Bagong Account  |