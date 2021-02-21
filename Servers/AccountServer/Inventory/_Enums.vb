Namespace AccountInventories
	<Flags> Public Enum AccountStatusFlags
		ACCOUNT_STATUS_FLAG_DEFAULT = 0
		ACCOUNT_STATUS_FLAG_IS_VIP = 1  ' for subscribers and others who get everything free
		ACCOUNT_STATUS_FLAG_DEBUG_VIP = 2 ' debug flag which doesn't get overwritten by loyalty update logic
	End Enum
	Public Enum AccountInventoryType
		kAccountInventoryType_Certification
		kAccountInventoryType_Voucher
		kAccountInventoryType_PlayerInventory
		kAccountInventoryType_Count
	End Enum





End Namespace