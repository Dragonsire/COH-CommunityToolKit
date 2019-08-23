# COH-CommunityToolKit
City of Heroes Portal Corp Toolkit
***Requires .Net 4.7.2 (Standard 2.0)

BEFORE YOU START
1.	You need Bin.PIGG (Client Version)
2.	You need Access to Server BINs for the additional MessageStore Files
3.	Fresh Startup will prompt for the locations of these files, and copy accordingly
4.	You can skip Assets Extraction, but GEO Textures won’t be available for viewing if not
5.	***Note Not all Pigg Files are Extracted in Regards to Textures (YET)

CURRENT KNOWN ISSUES:
1.	Not All UI Editors Save (Powers/PowerCats)
2.	Not All UI Editors Track Changes (Powers)
3.	Rebuild MessageStore BIN From Control Not Enabled
4.	Not ALL UI Editors Enable/Disable Appropriately
5.	I25 MultiRootBins, Not Working


Version 1.0.Alpha.92– 8/??/19 *Features Not fully Tested
•	DEF Serializer Now Understands Enum Flags
•	DEF Serializer Now Uses Enum DefName if enabled in Settings
•	DEF Serializer Now Uses XMLArrayItem to override Array Item Name

Version 1.0.Alpha.91– 8/??/19
•	Replaced Splash Background
•	Replaced Menu Background
•	Changed Name to Community Toolkit
•	Removed References to Portal Corps

Version 1.0.Alpha.90– 8/15/19 – MUST CLEAN START <84
•	XML Serializer Now Understands Enum Flags
•	XML Serializer Now Uses Enum DefName but only if forced as would need custom import
•	XML Serializer Now Uses XMLArrayItem to override Array Item Name
•	Fixed DEF Serializer Child Object Array With Empty ArrayItem
•	Fixed DEF Serializer Child Object Array Start/End

Version 1.0.Alpha.89– 8/13/19 – MUST CLEAN START <84
•	Export ALL XML – Menu Enabled
•	Export ALL DEF – Menu Enabled

Version 1.0.Alpha.88– 8/13/19 – MUST CLEAN START <84
•	XML Serializer Now Understands Enum Arrays
•	XML Serializer Will Now Use Enum DefName, When Serializing if Present
•	Error Dialog Now Shows CallStack
•	Error Dialog Now Can Be Min/Max
•	Fixed DEF Serialization Error Caused by Padding in Negative

Version 1.0.Alpha.87– 8/11/19 – MUST CLEAN START <84
•	Powersets i25 Read Supported 
•	Modified DEF Serializer to Remove Empty Structures

Version 1.0.Alpha.86– 8/10/19 – MUST CLEAN START <84
•	Enabled Export Bytes from Byte Inspection as .RAW
•	Enabled Export Bytes from BIN View Menu
•	Bytes to ClipBoard Limited to 100 Lines to Prevent ClipBoard Crashing
•	Moved Inherent, Pool, Pets etc extracted XML To Shared so will appear in UI
•	Added 3 i25 Score Properties Added to PowerFX
•	Reading Power DynamicParams

Version 1.0.Alpha.85– 8/8/19
•	Added Export XML/DEF Menu to BinView

Version 1.0.Alpha.84– 8/8/19 – MUST CLEAN START 
•	Cleaned Up PowerAttribute Mod to Use Localization
•	Added i25 Power Property Changes to COH_Powers
•	XML Serialization Versioning Support Added
•	DEF Serialization Versioning Support Added
•	Fixed XML Serialize, When Array

Version 1.0.Alpha.83– 8/8/19
•	Fixed Parse7 Pool String Reading
•	Fixed Parse7 Empty String Reading
•	Adjusted PowerCategories to Read Both Parse 6/7

Version 1.0.Alpha.82– 8/7/19
•	Modified Parse7 Bin View to Pull Names of Classes From Pool
•	Removed Duplicate Functions For Paarse7, that were not needed with Modified Approach
•	Added XML Serialize Partial on Fail
•	Changed Build Property to Attribute
•	Added BinVersion Property as Attribute
•	Added Only Show Project Attributes on Root Level
•	Combined STRUCT / OBJECT XML 
•	XML Serialiaze - Allow Enum as Attribute
•	Modified Import/Export to Stream to Call Protected Read/Write, to handle settings Better
•	MessageStore XML Reduced 50% -60% in size
•	XML Serializer, List Partially Now Supported
•	PIGG/BIN Resource Folder Now Has i24 & i25_Score For ContentPulling

Version 1.0.Alpha.81– 8/6/19
•	Added initial i25 support, Parse7 String reading, Parse7 String Array Reading
•	Parse 7 flags CurrentReader to Version 7
•	Character Classes Reading For Parse7 i25 Version

Version 1.0.Alpha.80– 8/3/19 – Must START FRESH!!!!!
•	Added Consistent Way To Display/Clear Project UI Details (IsCustom Etc)
•	Extract All Content / All MessageStores Separate Menus
•	ProjectFile Index Now Contains Originol Path Reference For Lookup
•	ProjectFile Relative Current and Originol Paths are now Properties Not Attributes
•	ProjectFile Index NowContains Full LookupName
•	Tree UI Now Uses Lookup Name Not XML Path
•	Export DEF Extension for Powers/Cats/PowerSets Overrides Added


Version 1.0.Alpha.79– 8/2/19
•	UI Editing PowerSet Save/Edit
•	Removed Wrapped Mod Details from Structs, Reworked All Affected Code
•	Mod Details Now Pull from ProjectFile, or Separate Info (Not Implemented)
•	Added pull name for exporting
•	Re-Enable BIN Rebuild For Powers/PowerSets/PowerCategories/CharacterClasses

Version 1.0.Alpha.78– 8/1/19
•	Added Menu Options For Serializing XML & Def in UI
•	Made DEF Export by default ignore defaults if marked
•	Made DEF Export by default ignore empty properties

Version 1.0.Alpha.77– 8/1/19
•	Fixed CRC32c Verification, Powers CRC read as UINT32
•	Moved Custom Marker and Was Modified Marker in UI
•	Added Support for Power ICON in Power Editor UI

Version 1.0.Alpha.76– 7/30/19
•	Fixed Power Lookup, When Additional Root Folder Element used
•	Power Editor Usage/Display/Target Options Control Layouts Added to Table

Version 1.0.Alpha.75– 7/29/19
•	Fixed Lookup PowerSet by Name Bug, now uses Relative Path
•	Minor Cleanup to Power Display Using Tables…Not Finished.

Version 1.0.Alpha.74– 7/25/19
•	All 4 Moddable Classes (Class, Cat, PowerSet, Power) Editors Now Supported in Unified
•	Removed Unlocalized Strings/Arrays from Class Structures
•	DEF Export Now Shows Content Prior to Error
•	DEF Export Write Child Objects as Structs, Need to Add Interface Overrides Where Applicable
•	Powers & Powers Categories Cleaned Up With Category Attributes and PString Class Updates

Version 1.0.Alpha.73– 7/25/19
Modified Character Class Editor into a User Control, Instead of Form
ModContent Now Use the Same Base User Control, For Consistent Experience

Version 1.0.Alpha.72– 7/24/19
Character Class Editor Export to Menus DEF / XML Enabled
Character Class Editor Undo Button Resets Content From Last Save
Monitor Instance Changes to COH_Struct Removed, Still Fires The Events
Save Enabled (Does Not Update Other Linked Conent (YET)

Version 1.0.Alpha.71– 7/22/19
Added Menu Items To Character Class Editor (Create, Import/Export)
Edit CharacterClass Name Not Editable Unless Custom
Added COH_CheckListBox, To Allow ShortCut Methods, and Checklist Change
Fixed DEF Export String Array Writing
First 3 Tabs of Character Class Editor, Now Edit Appropriatly 

Version 1.0.Alpha.70– 7/22/19
MUST BE FRESH START ***MASSIVE*** STRUCT CHANGES
FRESH START MIGHT ALSO BE BROKEN
Moved all Controls For Editing Projectfiles AKA Mods, To Modding Sub Project
Removed All Project Related Properties From COH Structs to Modding Details Class
Reimplemented All Editable Project Files Under New Structure System
Removed All XML Project Related Properties Related to IsProject from Serialization Systems
COH_Moddable_CharacterClass Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_Power Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_PowerCategory Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_PowerSet Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_Character Origins Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_AttribNames Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_AttribDescriptions Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_TRICKS Added to Implement Project Contents Removed From StuctVersion
COH_Moddable_TextureOptions Added to Implement Project Contents Removed From StuctVersion
Added XML Serializer Support for basic Enums
***Trick Lookup From GEO Viewer Broken, Until Other Systems Modified.


Version 1.0.Alpha.69– 7/21/19
Fixed DEF Serialize, Full Class Name Without Multiple Attributes or Without COH_TOK
Moved Tools Menu / Combined With Editors
Character Class Editor Moved to New Editors Menu
Character Class Implemented Advanced Edit
Character Class Added PString, Create New (Does NOT Add to Message Store *** WILL DURING UNKNOWN PROCESS)
Character Class Editing PSTRING Values Editing Through UI
Character Class Live Changes when editing ICON String
Fixed Character Class Attributes Tables Showing Project Strings in Table

Version 1.0.Alpha.68– 7/20/19
Moved AboutBox Control to Controls Project
Added Version String to Splash Screen
Added 2 Def Related Interfaces for Converting to String / String Array for Primitive String Generic Types
Expanded upon Was Modified Current Instance of an Object for Tracking Changes (UI Related)
Character Class Now Listens for Event Changes for Attributes, and Marks CurrentInstance as Modified
Character Class Now Listens for Event Changes for AttributesTable, and Marks CurrentInstance as Modified
If Class AlreadyModified Does Not Raise Event
Events/Modified Don’t get Raised When Initializing
Initializing Added to COH_Struct Clone and XML Import
Fixed Asset Lookup TGA for GEO
Character Class Icon Lookup Added to Editor
DEF/XML/PropertyGrid Realtime Preview Added to Chatacter Class Editor


Version 1.0.Alpha.67– 7/19/19
REQUIRES FRESH Extract Player & NPC Classes
***Begin Process Replace Some Primitives With More Controllable Serializable Structures
Added Generic CrypticS_String (Localized & Not Localized Classes)
Added Generic CrypticS_StringArray (Localized & Not Localized Classes)
Added Generic CrypticS_String_NonAligned AKA Fixed (Short or Integer Marjer)
Updated CharacterClass Editor To Use New Class
Updated XML Serializer To Understand Numeric Default =0 and String Default =””When not Specified
Added INotifyPropertyChangeSystem to COH_Struct
Fixed Child Struct, Project Related Properties being Serialized to XML when not Parent
Added Override for NonLocalized String to Appear as Strings in XML, Widening Used
XML File Export Now Uses the Custom XML Serializer Export Method
DEF Serializer Enabled (Partially Functionable)
TOK ENUM Attribute Added to Override NAME, Min/Max Version, Build, TOK Type (or Undefined) for Serializing

Version 1.0.Alpha.66– 7/17/19
Added XML Debug Attribute to CustomXML Serializer, to Flag Non Relevant Details (Must be applied to each property)
Added UI CheckBox To Enable/Disable Debug Values in XML
Added CrypticS_String for Pstring Simplification
Begin process of Merging LocalizationController, to BinaryReader
CharacterClasses Updated To Use  CrypticS_String, Removed From UpdateMap, As they Should be Handled Independent
Updated Character Class Editor To Reflect Property Changes
Added Split Container To GEO Viewer For Resizing Model / ModelSection Areas

Version 1.0.Alpha.65– 7/16/19
Extract All Skeleton Files From ANIM Menu Option Added
GEO Viewer does not import all available Skeletons, for simplification
Fixed Custom XML Option to Not Show Project Related XML when selected
Monorails.bin to XML Now Supported / Rebin (Not Yet)
DayJobs.bin to XML Now Supported / Rebin (Not Yet)
storyarcmsg-en.bin Added to MessageStore
NictusHunterOptions.bin to XML Now Supported / Rebin (Not Yet)
NewFeatures.bin to XML Now Supported / Rebin (Not Yet)
SouvenirClues.bin to XML Now Supported / Rebin (Not Yet)

Version 1.0.Alpha.64– 7/15/19
Added Generic Event Message to be called from EventController
Added Skeleton to Assets
GEO Viewer No Longer Searches ANIM for Bones, it Searches pre-extracted Male/Female Bones
Added Ability to Switch Bones Used in Viewer Male/Female

Version 1.0.Alpha.63– 7/14/19
Added Non Animated Bone Version To GEO View, Each Bone Is Separate
Bone View IN GEO now indicates with a different Color if Bone is Used
New Bones AdjustedView for Models With Bones Button (Toggles , Off by Default)

Version 1.0.Alpha.62– 7/14/19
Added Stream Release to BIN VIEW
Custom Texture Name Search adjusted
Added Texture Viewer
Add Error Checking for Missing Skeleton in GEO View
Fresh Install Prompt for Additional Pigg Extraction
ANIM Pigg Extract added to Extract ALL
Added Asset ReScan On Extract Menus

Version 1.0.Alpha.61– 7/13/19
Replaced Changes Made to Hierarchy with First Positions, to New Struct…to prevent confusion
New Skeleton Structure Stores First Position and Connected Positions
Addjusted Treeview Bones H to Show Base Name and use new struct
Bone Details Now Shows Both Position and Connected Position
Moved some of the Project Readonly Properties to Functions, less cluttering Intellisence
Enabled Menu to open a Single Bin for view
storyarc.bin to XML Now Support (Not 100% Confirmed)
Custom XML Now The Default…Still Testing
Added Root Style for Some Bins to Display

Version 1.0.Alpha.60– 7/11/19
Display Bone Tree Hierarchy
Display GEO Bones

Version 1.0.Alpha.59– 7/8/19
Replaced GridVersion Used, Back to LineGeometry 3 Sizes based on Model Size
Add Model Creation for Axis / Slot Indicator
Added Prototype Center Axis When Displaying Grid
Center Zoom now Uses NewMethod of Calculating Bounding Box On Model, not Bound Area in Model
Center Zoom Calculates Based on Currently Visible Models
Prioritized Display BONEID_Default over BONEID_HIPS Even though Both Zero
Display list Bone IDs Used
Display Bone Weight per vertex
Display Vertex Bone Assignment

Version 1.0.Alpha.58– 7/7/19
Pigg Extraction Now Looks to see if it can find missing file in last location before prompting for location 

Version 1.0.Alpha.57– 7/7/19 
Tricks Now Viewed in GEO View Mode
Fixed Tricks and Textures Being Extracted Twice

Version 1.0.Alpha.56– 7/7/19 
Fixed Export ANIM to XML using Viewer
Fixed Select/Unselect Specific Models

Version 1.0.Alpha.55 – 7/7/19
***NEEDS FRSH START < Version 54*****
Pulls Texture Resource Upon GEO Open
Fixed Assets Lookup, Using Dictionary for Speed
Fixed TextureBinds to Model
Fixed Control Forms Preview Initialize Without Controller in Design mode
Fixed Toggle On/Off Models From List
Populate Material List Based on Model Selection
GEO View Now Uses GroupModels For Models to Allow Material Group Models
View GEO Texture Now Working
OBJ Export Now Supports UV Coordinates
Adjusted Method of Releasing Images for Various Functions
Fixed Bug Causing Model Display to trigger 3 times when used in form
Added Toggle on Off Materials

Version 1.0.Alpha.54 – 7/6/19
***NEEDS FRSH START*****
FIXED DDS NAME BUG
FIXED Export Resource Files
Separated Binding DataContext GEO Window, So is like Code Now and Not Annoying Bindings
Removed All WPF Code Except For ViewPort, Merged back to forms for better control
Added Parent UserControl Template / Same as Form To Eventually Control Color Schemes Etc
Added TGA Support
Changed ZLIB Decompression Method
Added Assets Controller (Partial)
Added Project Support For Bins With more than 1 root element
Added View Project / Fresh Start support for Bins with more than 1 Element
Added Extract BIN to XML with more than 1 Root Element to separate sub folders
Additional Texture Piggs Setup To Extract Easily
Switched To MasterControl Interface, When Passing to Controls
Removed Numerous Separate Functions For Struct of Type Retrieval and Combined into Simpler
CrypticS File Storage Structure Moved to GameContent
ProjectFile Moved to GameContent
All Control Editors Moved to Controls Sub Project
All Controls / Forms Now Get Declared Linking To Master Controller

Version 1.0.Alpha.53 – 7/3/19
***NEEDS FRSH START < Version 50*****
Pigg Extract Now triggers ProgressBar
Pigg Extract Can now Extract The Textures Files and DDS Versions During Single Extraction Slot written as Raw
Resource Folder Assets Renamed _PIGG
Resource Folder Assests Now For Extracted Assets – BINs Textures Etc
Merged Serialize Settings Into Both Text and Stream Parsing Functions
Simplified All Serialization , Removed the Need to Pass Settings
Illiminated Additional Inheritance for Resources that was redundant
Additional Stability for CUSTOM XML Serialization, Handles Non COH_Structs Better
-BUG- DDS Adding FolderName to File When Extracting

Version 1.0.Alpha.52 – 7/2/19
***NEEDS FRSH START < Version 50*****
Custom XML Serialization in Testing, With Passable Variables
>>Hide Empty Values
>>Hide Project Properties
>>Hide Default Values, Requires Default Attribute Set, And Maybe an Interface that can communicate with Struct for versioning if need be
>>UI To Control XML Settings, Will Also get added to Project Settings File and Passed Auto once Stable
2nd XML Tab Added for comparing

Version 1.0.Alpha.51 – 7/1/19
***NEEDS FRSH START < Version 50*****
Fixed Localization Being Ignored for Costumes.BIN
Fixed Bone Hierarchy not trying to read 100 Bones, like struct says as it’s ignored
Fixed COH REF Import/Export Code was missing???
Fixed Exit Menu

Version 1.0.Alpha.50 – 6/30/2019
***MAY Need Fresh Start ***** Numerous XML Basic Structs converted to Attributes
Moved Numerous Controls into Controls Library
Removed Import/Export Stream Format Separators as Was complicating Things, Format Flag Still an Option
Added Read ANIM Files, Not All Rotation Decompression Supported (Non Linear Likely Buggy)

Version 1.0.Alpha.49 – 6/29/2019
***NEEDS FRSH START < Version 46*****
Added TypeDescriptor To COH Struct, to Hide ProjectFile Details When not a Project File
Enabled Pigg Open File Dialog to open other Pigg Files Containing BINS, GEOs etc
Added GEO Detail List, Where it breaks down basic features of a model
Disabled Model ID 65534 from skipping (More Body Geos Display)

Version 1.0.Alpha.48 – 6/28/2019
***NEEDS FRSH START < Version 46*****
Fixed Various Rebuild Bins Functions (Not All Tested)
Overhauled Geo Preview Code, So Model Needs Only to read in once Instead of every change of option/view etc
Show Basic Bounding Box
Select All Models In GEO View
Additional Rendering Options in GEO View
Reset Position, on New Model & Reset Button 
Center Position Added on GEO View

Version 1.0.Alpha.47 – 6/27/2019
***NEEDS FRSH START < Version 46*****
Fixed MeshGroup List
Fixed Unsupported Bin From Crashing In Some Situations

Version 1.0.Alpha.46 – 6/26/2019
***NEEDS FRSH START*****
Fixed Power View With No AI Rank (Table)
Fixed Fresh Start Registering Known File Types

Version 1.0.Alpha.45 – 6/26/2019
Fixed GEO Decompression

Version 1.0.Alpha.44 – 6/26/2019
PIGG View  Now Supports Message Stores
Added Basic MessageStore View
Added Supported For Message Sores Without Variables
Converted Bin Register to Controller for all Libraries, Setup Pigg to Use Controllers Upon New
Removed LanguageMap passing in Pigg Bin, Now only Passed once
Added Struct Controller to PiggBin, Passed to Cryptic To Handle All Registered Types (could be Expended for plugins)
Added View Vertex Point on Mesh
Fixed Model multiple load on first open

Version 1.0.Alpha.43 – 6/25/2019
Fixed DLL Locate For Resource DLL
Expanded Inheritance Structure for COH_Struct to Include Build Format Flag (Server/Client)
Added Overridable Default File Ext for CrypticS (DEF) formats and Binary (Raw, GEO etc)
Removed Separate Library Events Controllers, Now Using Central Version From Primary Inheritance
Added the inheritance structures required to write various string formats
Fixed FX BehaviorOverride not ByteAligning
Added ShouldSerialiaze Staments to Root Inheritance, to Declutter Non Tracked ProjectFiles
IsProjectFile Added to Serialize Tracked Content
FX_INFO.BIN to XML Now Supported / Rebin (Not Yet)


Version 1.0.Alpha.42 – 6/24/2019
Folder Merge / Cleanup For Structures
PC_Def_UI.BIN to XML Now Supported / Rebin (Not Yet)
MiniMap.BIN to XML Now Supported / Rebin (Not Yet)
MenuAnimations.BIN to XML Now Supported / Rebin (Not Yet)
Mapstats.BIN to XML Now Supported / Rebin (Not Yet)
MapSpecs.BIN to XML Now Supported / Rebin (Not Yet)
Map.BIN to XML Now Supported / Rebin (Not Yet)
Arenamaps.BIN to XML Now Supported / Rebin (Not Yet)
Auctionconfig.BIN to XML Now Supported / Rebin (Not Yet)
BaseRecipe.BIN to XML Now Supported / Rebin (Not Yet)
Conversionsets.BIN to XML Now Supported / Rebin (Not Yet)
defaultBodyCfg.BIN to XML Now Supported / Rebin (Not Yet)
CustomCritterRewards.BIN to XML Now Supported / Rebin (Not Yet)


Version 1.0.Alpha.41 – 6/24/2019
PC_Def_Entities.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_DestructObject.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_NonSelectableEntities.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_Animation.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_MapUnique.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_MapSet.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_Sequencer_Anims.BIN to XML Now Supported / Rebin (Not Yet)
Added Environment Option Menu, Add MSBuild to Environment Path for Ease
Added crude download method for Git For Windows
Added Crude .bat file generate for powershell to rebuild SourceCode
Added Git Clone Download For SourceCode (Ouroboros)

Version 1.0.Alpha.40 – 6/24/2019
Particles.BIN to XML Now Supported / Rebin (Not Yet)
Added Struct Versions of Vector 2,3,4
Ent_Types.BIN to XML Now Supported / Rebin (Not Yet)
Fixed Bug With Error Dialog When no Exception has occurred, just message
replacementpowernames.BIN to XML Now Supported / Rebin (Not Yet)
Proficiencies.BIN to XML Now Supported / Rebin (Not Yet)
ProficienciesIds.BIN to XML Now Supported / Rebin (Not Yet)
PC_Def_Unlockable_Content.BIN to XML Now Supported / Rebin (Not Yet)
texWords.BIN to XML Now Supported / Rebin (Not Yet)

Version 1.0.Alpha.39 – 6/23/2019
Added Replacement Error Box, to show the details **Error Reporting still needs implemented in many places
ColInfo.BIN to XML Now Supported / Rebin (Not Yet)
Added Versioning Support to ResetDefaults
Capes.BIN to XML Now Supported / Rebin (Not Yet)
PowerCustomizationCost.BIN to XML Now Supported / Rebin (Not Yet)
PowerCustomizationMenu.BIN to XML Now Supported / Rebin (Not Yet)
ColWindInfo.BIN to XML Now Supported / Rebin (Not Yet)
boost_effect_above.bin to XML Now Supported / Rebin (Not Yet)
boost_effect_below.bin to XML Now Supported / Rebin (Not Yet)
boost_effect_boosters.bin to XML Now Supported / Rebin (Not Yet)
exemplar_handicaps.bin to XML Now Supported / Rebin (Not Yet)
combine_chances.bin to XML Now Supported / Rebin (Not Yet)
combine_same_set_chances.bin to XML Now Supported / Rebin (Not Yet)
combine_booster_chances.bin to XML Now Supported / Rebin (Not Yet)
boostsets.bin to XML Now Supported / Rebin (Not Yet)
dim_returns.bin to XML Now Supported / Rebin (Not Yet)
seqstatebits.bin to XML Now Supported / Rebin (Not Yet)
chestgeolink.bin to XML Now Supported / Rebin (Not Yet)
sequencers.bin to XML Now Supported / Rebin (Not Yet)

Version 1.0.Alpha.38 – 6/22/2019
Removed CrypticS Inheritance Struct
Moved to Inherited Format Read Method, CrypticS  & Binary
Fixed Startup Inheritance Issue Preventing Load
Color Adjustments to XML Viewer
LoyaltyRewards.BIN  to XML Now Supported / Rebin (Not Yet)
Supergroup_badges.BIN  to XML Now Supported / Rebin (Not Yet)
VillianCostume.BIN  to XML Now Supported / Rebin (Not Yet)
BehaviorAlias.BIN to XML Now Supported / Rebin (Not Yet)
Behavior.BIN to XML Now Supported / Rebin (Not Yet)
>>Unknown TOK_USED FIELD, appears to add 16 twice, then 12 bytes, reads bytes and moves on for now.
Fixed Byte View Refresh
PopHelp.BIN to XML Now Supported / Rebin (Not Yet)
kb.BIN to XML Now Supported / Rebin (Not Yet)
kbkorea.BIN to XML Now Supported / Rebin (Not Yet)
Added Generic String Array Class instead of Just COH_Reader_ReadStringArrayStruct since BIN exists that is this
SupergroupEmblems.BIN to XML Now Supported / Rebin (Not Yet)
SupergroupColors.BIN to XML Now Supported / Rebin (Not Yet)
SoundInfo.BIN to XML Now Supported / Rebin (Not Yet)
Added Quick Byte to Clipboard Button on ByteView

Version 1.0.Alpha.37 – 6/21/2019
Replaced Virtual ListView with Virtual GridView
Tailorcost.BIN  to XML Now Supported / Rebin (Not Yet)
Experience.BIN  to XML Now Supported / Rebin (Not Yet)
BaseUpKeep.BIN  to XML Now Supported / Rebin (Not Yet)
Items.BIN  to XML Now Supported / Rebin (Not Yet)
Stores.BIN  to XML Now Supported / Rebin (Not Yet)
Schedules.BIN  to XML Now Supported / Rebin (Not Yet)
debts.BIN  to XML Now Supported / Rebin (Not Yet)
Animlists.BIN  to XML Now Supported / Rebin (Not Yet)
InvSalvage.bin  to XML Now Supported / Rebin (Not Yet)
InvStoredSalvage  to XML Now Supported / Rebin (Not Yet)
InvConcept.bin  to XML Now Supported / Rebin (Not Yet)
InvRecipe.bin  to XML Now Supported / Rebin (Not Yet)
InvBaseDetail.bin  to XML Now Supported / Rebin (Not Yet)
Added Syntax Hilight to XML Viewing

Version 1.0.Alpha.36 – 6/20/2019
Modified Files Entry in Cryptics For MultiRoot Structures Like Tricks.bin
Moved Original Sources to Main Class in Cryptics (May have temporarily broken rebin)
Tricks.BIN to XML Now Supported / Rebin (Not Yet)
Defnames.BIN to XML Now Supported / Rebin (Not Yet)
Salvage.BIN  to XML Now Supported / Rebin (Not Yet)
BodyParts.BIN  to XML Now Supported / Rebin (Not Yet)
Command.BIN  to XML Now Supported / Rebin (Not Yet)
Plots.BIN  to XML Now Supported / Rebin (Not Yet)
RoomTemplates.BIN  to XML Now Supported / Rebin (Not Yet)
Roomcategories.BIN  to XML Now Supported / Rebin (Not Yet)
Detailcats.BIN  to XML Now Supported / Rebin (Not Yet)
Details.BIN  to XML Now Supported / Rebin (Not Yet)
Added Temporary Version of Byte Viewer to Bin View Tab, for Raw View

Version 1.0.Alpha.35 – 6/19/2019
Added Additional TRICK Related Structures
Renamed CrypticS Solution to Structures, Added NameSpace Structures and removed from individual classes
Added Format to Binary Reading/Writing as Some Structs Parse Different Depending on Storage Example AutoLOD , EmbeddedStructs etc

Version 1.0.Alpha.34- 6/18/2019
Added additional Support for Version 4,7,8 (Still buggy)
Cleaned Up sources more Added Additional Structs /read order for differences between parsing methods of AutoLOD
Added Forms Project For Moving All General Controls Etc To
Split Trick Name For Display
Added Position Event to BinaryReader
Added Developer ByteView Trigger
Fixed Alignment With GEO Version 7 & 8
Fixed Alignment With GEO 2/3/4 (*I Think)

Version 1.0.Alpha.33- 6/18/2019
Fixed Load LOD Info / Casting to Wrong Type
Some Namespace Cleanups
Couple Small UI Changes to GEO View

Version 1.0.Alpha.32- 6/16/2019
Switch Viewport Control to one that supports Bones
Adopted Most of the Code added to Regular Viewport
Separated WPF Controls
Added some valid geo checks for data that it doesn’t understand yet to try and prevent crashes or memory hangups  trying to decompress data

Version 1.0.Alpha.31- 6/15/2019
Updated Control Namespaces
GEO Model View Added (Version 0 to 3 only) ** others crash
GEO UI, Flag View only Specific Models
GEO UI, Groups have own Color
GEO UI, Grid View
GEO UI, Basic Wireframe, Not All Edges
GEO Single Model Export to OBJ (Basic, NO UI Element Yet)
GEO Multi Groups Export to OBJ (Tab on UI)

Version 1.0.Alpha.30 - 6/13/2019
GEO Header Version 0 to 3 Reading Header/Models/PackData
Inheritance Structures Update/Merged

Version 1.0.Alpha.29 - 6/12/2019
Add Property Readonly View to Pigg View
Added FileName back to DDS Header Info
Updated Temporary SplashImage

Version 1.0.Alpha.28 - 6/12/2019
Fixed Build/Extract Function After Code Split – Believe Fixed**
Fixed Preview DDS, Additional Header Information Read
Added Interface replacing MessageStore Lists for passing, and allowing more control down the road.
Fixed Message Store – Server Side Rebuild (Was Rebuilding Client by Error)
Fixed Display Attribute Table, Ignoring DisplayName when reading properties
Fixed Add New Message to Message Store
Added Ability to Edit Custom Message Store Entry

Version 1.0.Alpha.27 - 6/11/2019
Added Numerous Structures (Untested) for GEO, Basic Texture, Basic Mesh Support
Split Projects Into Sub Projects, using Interfaces / Inheritance to Allow for Modular Support
Added ground work to make plugin compatible

Version 1.0.Alpha.26 - 6/10/2019
Added Locate PIGG File To Pigg Editor Open 
Added 2 additional Pigg Files to Menu for Testing purposes
Added Support for BuildCRC to Bin Type Search / Identify
Moved More Code From Piggy to Game Content
Added Initial Support for GEO

Version 1.0.Alpha.25 - 6/10/2019
Added XMl Conversion Support for Villain Groups
Added XML Conversion Support for Villain
Added XML Conversion Support for Badges
Added XML Conversion Support for SuperPacks
Added XML Conversion Support for LOD Info
Added XML Conversion Support for Costumes
Add Localization Support To Many of the Structures Above and Some Substructures also

Version 1.0.Alpha.24 - 6/9/2019
Fixed BIN Write Bug that caused double time stamp
Moved Cryptic Binary Read/Write to GameContent Class Files, Instead of Separate Build Functions
Added Versioning for future proofing 
Fixed CharacterClass Writing Localized Text instead of PString Values
Fixed Power Extract to XML, Folder Filter 
CrypticS Settings Class Added For additional options
Rebuild From Combined Broken **Temporary
Index Added to CrypticS Info to support Combined Records

Version 1.0.Alpha.23 - 6/8/2019
Cleaned Up ProjectFile, Bin Support no Longer Restricted 
Merged Import for GameContentFile
Added Import/Export XML Error Notifications
Added ProjectFile Editing
Custom/Modified Added to CrypticS Info for faster identifying
Added Foundation Structure for Import/Export Mod Initial Structure

Version 1.0.Alpha.22 - 6/7/2019
Added PropertyGrid to BinView
Added Some Category Attributes to Character Class for better read layout
Added Initial Support for Error Handling / Logging
Added check supported bin to treeview colorizes unsupported to red
Keep Same Control In Preview if next Preview is same type

Version 1.0.Alpha.21 - 6/7/2019
Cleaned up / Simplified Progress Update Notifications
Additional UI elements added to powers edit ui

Version 1.0.Alpha.20- 6/6/2019
Changed Origin Class to Inherit GameContentFile
Changed Contact Class to Inherit GameContentFile
Changed Contact Categories Class to Inherit GameContentFile
Changed NPC Class to Inherit GameContentFile
Changed Attribute Category Class to Inherit GameContentFile
Changed Attribute Names Class to Inherit GameContentFile
Changed Product Catalog to Inherit GameContentFile
Changed Product Catalog Item to Inherit GameContentFile
Updated Character Class UpdateMap CodeStyle
Updated Power Category Class UpdateMap CodeStyle
Updated Origin Class UpdateMap CodeStyle
Converted BIN ViewForm to Control For Use in PigView and Added Control Back to form to function as previous

Version 1.0.Alpha.19 - 6/6/2019
Added Resource Class for handling Pigg Entries that are not BINs
Cleaned up DDS Extraction, and Preview
DDS Processing Now handled in GameContent DLL instead of Tools, New Dependency Files Added
Added Compare Import For Message Stores
Added Event Compare 2 Strings Dialog

Version 1.0.Alpha.18 - 6/5/2019
Minor Cleanup To Deep Cloning
Added Initial Support For Villains (Enemies)
Added Initial Support for Villain Groups (Enemy Groups)
Re-Worked PiggTool to CodeFlow similar to CrypticS BinTool
Added Initial Framework Support for PiggViewer
Very Basic DDS Support

Version 1.0.Alpha.17 - 6/4/2019
Added CRC-32 Tool

Version 1.0.Alpha.16 - 6/4/2019
Power CRC-32c Check Implemented, Verified against existing content
Added Support for additional PStrings in Powers
Added very Basic Color Selection ComboBox Control
Added Numerous UI Elements to Power Editing (OnGoing)

Version 1.0.Alpha.15 - 6/2/2019
Made some UI Tweaks to Couple Editors
Created Abstract GameContentFile, For Less code Duplication Going Forward
Changed Character Class to Inherit GameContentFile
Changed PowerSet Class to Inherit GameContentFile
Changed PowerCategory Class to Inherit GameContentFile
Changed Power Class to Inherit GameContentFile
Removed XML Header Crap From Output
Basic Code Flow for Color Scheme to Form Template
Moved Code back from ProjectFile for Caching, to Controller (In Case Change)
Added Custom Content Indicator & Modified From Source Indicators
Added Folder Sorting to Powers Extraction
Updated Search XML GameContent XML File to Avoid Caching all Files
Code Paths added to Display Powers UI

Version 1.0.Alpha.14 - 6/1/2019
Added TreeView PowerCategories / PowerSets to PowerSets UI Editor
Added Support for Addition PStrings within PowerSet
Full UI View Support PowerSet

Version 1.0.Alpha.13 - 6/1/2019
Removed Unnecessary Attribs Array & Tables Array From Character Classes
UI For Viewing Character Classes Ready (Features to Edit Not)
** Make sure to Re-Extract Character/Enemy Classes Before Viewing

Version 1.0.Alpha.12 - 6/1/2019
Added Cursor and Icon to Splash Screen
Added Tooltip to Form Template
Repaired Additional UI Editing Elements for Classes
Many UI Elements now have tooltip for editing classes
Some Combo/Checklist box now add elements by searching all used structures
Added Option to Settings File – Update BIN Time Stamps (Default False)
Added Option to CrypticS File – Update BIN Time Stamps (Default False)
Allow FileDate As Date to Write to CrypticS as Reference Only
Option to Update Time Stamp Gets Updated From Settings When Rebuilding

Version 1.0.Alpha.11 - 5/31/2019
Added Support to Extract PC_Def_Contacts.bin (Not Extracted by Default)
Added Support to Extract npcs_client.bin (Not Extracted by Default)

Version 1.0.Alpha.10 - 5/31/2019
Couple Small Fixes
Some of The Character Classes UI Working for Viewing Again

Version 1.0.Alpha.9 - 5/31/2019
Added Product-Catalog.BIN as a combined XML. Rebuilds Unaltered 1:1 (Not Extracted by Default)
Added Text Search to MessageStore Edit
Added Text Search Find Next to MessageStore Edit

Version 1.0.Alpha.8 - 5/30/2019
Replaced extraction Progress Bar with Basic Non-Animated Version
Removed User Project / Standard and Combined into Project, With Custom Field / Change Field
Updated Redundant Instance Reference For Primary Controller
Added Basic Settings File
Moved Loaded Project Info Settings to Settings
Standard Project Package Now Created By Default When Starting Fresh
Standard Package Now Supports Cached Contents For Editing. Origins & Character Classes Only So Far
Class Editor Now Uses ProjectFile as Data Soource
Class Primary & Secondary Filled from All Available / Used
Origin CheckListBox Fills From All Defined Classes.bin and Villain-Classes.bin
Fixed PString Map Update Character Classes (Not Sure How many others affected) Will Investigate
Class Editor Tree Now Pulls From Project File

Version 1.0.Alpha.7 - 5/29/2019
Added Name Field to CrypticS to ContentEntry
Started Merging CrypticS BIN Index info to Project
Switched to Retrieve FileName from Class instead of strings
Extracting Progress / Writing XML Stages correctly Identifies
Extraction ProgressBar Altered For Less Refreshing
ProgressBar Percentage should be more accurate, titles still wrong
Enabled First Startup Extract Setup

Version 1.0.Alpha.6 - 5/28/2019
Added Bin File Name to Structure Mapping For Future Expansion
Minor Menu Cleanup
powercats.bin Rebuild 1:1 Unaltered (Working)
powersets.bin Rebuild 1:1 Unaltered (Working)
Fixed Attribute Duration Being Ignored
Fixed Ignore VisualFX String
Fixed Ignore CustomFX Parsed Return
Replaced Color with  XML Color Wrapper, As Was Being Ignored
Fixed Ignore Power FX within Custom FX
Fixed Zero out SuppressPair when rebuilding
Fixed Not Extracting Files with Path _1x at the end
Powers.bin Rebuild 1:1 Unaltered (Working)

Version 1.0.Alpha.5 - 5/27/2019
Added preliminary ui for BIN View Tool
Origins.BIN Rebuild 1:1 Unaltered (Working)
Villain-Origins.BIN Rebuild 1:1 Unaltered (Working)
Classes.BIN Rebuild 1:1 Unaltered (Working)
Villain-Classes.BIN Rebuild 1:1 Unaltered (Working)

Version 1.0.Alpha.4 - 5/26/2019
Reworked Bin Tool Into 2 Separate Tools. 1 For CrypticS Content, 1 For MessageStores
Added More Generic Extraction System to Allow for Additional Utility Usage
Massive Code Flow changes to Allow BinTools to allow info without extraction for view tool purposes
Individual Structure Extraction Now Possible
***Introduced Progress Display Bug from the way code now extracts
***powers slower to extract because progress bar updating too often

Version 1.0.Alpha.3 - 5/25/2019
Re-Added Write Functions for COH_Binary CrypticS String Related
Added File Mapping System to Create File Entries in BIN (Replicate Def Structure) ** Shouldn't matter, but just incase.
Added DEF / XML Reference to Structures where needed...some will need to be redirected as info exists...but for now added to all applicable
Removed Bin Index, No Longer Required
Started Cleanup on Export to XML so less Hardcoded feel
Reworked BinTool To Support Multiple File Tables (Futureproofing)
Added Support To XML Bin File Info For Indexing and Process to Rebuild Files Easier
Fixed MessageStore Cloning
Fixed MessageStore Display Variables
Fixed Locate File Bug
Fixed Search MessageStore for Empty String

Version 1.0.Alpha.2 - 5/25/2019
Added Locate File Function to some Bin/Pigg Extraction Functions
Re-Added Some Menus for Pigg/Bin Extraction
Moved/Expanded Library Events to Allow more Extraction Progress Stuff etc.
Enabled Additional Press Bar Stuff
Switched Message Store From List to Dictionary **Faster when processing a lot of files. **Not Fully Tested
 
Version 1.0.Alpha.1 - 5/24/2019
All Edit Forms Now Inherit From Single Form (Future Templating)
Added Code to Keep Track and Monitor Open Windows for Disabling Menus Etc. (Future Plans)
Added Code For Populating Search in Editor, for linking from other Forms
Some Partial Class Cleanup
Enabled main Screen / Temporary Graphics

Version 1.0.Alpha.0 - 5/24/2019
Combined Mapped and Original Language Files into 1 System, to remove redudency
Added Additional Indicators on MessageStore Edit Screen
Fixed Allow Editing/Saving Text
