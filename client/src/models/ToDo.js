export class ToDo {
    constructor(data) {
        this.description = data.description
        this.id = data.id
        this.completed = data.completed || null
        this.creatorId = data.creatorId
    }
}