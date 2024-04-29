export interface UserInfo {
    email: string,
    userName: string, 
    bookClubs: BookClub[] 
}

export interface BookClub {
    clubID: number,
    clubName: string,
    isOwner: boolean
}