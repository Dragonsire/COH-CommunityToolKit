﻿Namespace CodeManagement.Enums.Structures
    Public Enum StructTokenType
        Undefined = 0 '//ALLOW PROPERTY TO SERIALIZE NORMALLY


        TOK_IGNORE ' do nothing with this token, ignores remainder of line during parse
        TOK_START ' not required, but used as the open brace for a structure
        TOK_END ' terminate the structure described by the parse table

        ' primitives - param=default value
        TOK_U8_X ' U8 (unsigned char)
        TOK_INT16_X ' 16 bit integer
        TOK_INT_X ' int
        TOK_INT64_X ' 64 bit integer
        TOK_F32_X ' F32 (float), can be initialized with <param> but you only get an integer value
        TOK_DEGREES_X ' As F32. Radians in binary but degrees in text. DefineLists in radians.
        TOK_STRING_X ' char*
        TOK_CHAR_X ' non-null terminated char*
        TOK_RAW_X ' specify size as parameter, this many bytes will be written to binary as is
        TOK_POINTER_X ' void*, param is offset to size in bytes

        ' built-ins
        TOK_CURRENTFILE_X ' stored as char*, filled with filename of currently parsed text file
        TOK_TIMESTAMP_X ' stored as int, filled with fileLastChanged() of currently parsed text file
        TOK_LINENUM_X ' stored as int, filled with line number of the currently parsed text file
        TOK_USEDFIELD_X ' stored as pointer, allocated by textparser, any fields given in text file will set corresponding bits
        TOK_BOOL_X ' stored as u8, restricted to 0 or 1
        TOK_FLAGS_X ' unsigned int, list of integers as parameter, result is the values OR'd together (0, 129, 5 => 133), can't have default value
        TOK_FLAGARRAY_X ' int[], list of integers as parameter, result is turning on the bits in the int array for the values (0, 1, 32, 34, 63 => { 0x00000003, 0x80000005 }), can't have default value
        TOK_BOOLFLAG_X ' int, no parameters in script file, if token exists, field is set to 1
        TOK_QUATPYR_X ' F32[4], quaternion, read in as a pyr
        TOK_MATPYR_X ' F32[3][3] in memory turns into F32[3] (PYR) when serialized
        TOK_CONDRGB_X ' U8[4], conditional RGB. Alpha is 255 if the parameter is parsed, 0 otherwise.
        TOK_FILENAME_X ' same as string, passed through forwardslashes & _strupr

        ' complex types
        TOK_LINK_X ' link to another object in a different parse file
        TOK_REFERENCE_X ' YourStruct*, subtable is dictionary name
        TOK_FUNCTIONCALL_X ' StructFunctionCall**, parenthesis in input signals hierarchal organization
        TOK_UNPARSED_X ' StructParams**, getting almost unparsed tokens
        TOK_STRUCT_X ' YourStruct**, pass size as parameter, use eaSize to get number of items
        TOK_STASHTABLE_X ' StashTable
        TOK_BIT ' A bitfield... only generated by AUTOSTRUCT
        TOK_DEPRECATED ' A field that is no longer used. TODO: won't work on sub structs, but that might be nice one day

        NUM_TOK_TYPE_TOKENS
    End Enum
End Namespace