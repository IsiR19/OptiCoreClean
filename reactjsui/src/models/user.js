export default class User {
    constructor(userId, fullName, email, type, parentUserId, subordinateUserIds, subordinateCount, totalCommission) {
        this.userId = userId;
        this.fullName = fullName;
        this.email = email;
        this.type = type;
        this.parentUserId = parentUserId;
        this.subordinateUserIds = subordinateUserIds;
        this.subordinateCount = subordinateCount;
        this.totalCommission = totalCommission;
    }
}