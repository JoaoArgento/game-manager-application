export type GameDTO = 
{
    id: string
    name: string
    description: string
    logoPath: string,
}


export type CreateGameDTO = 
{
    name: string,
    description: string,
    logoPath: string,
}