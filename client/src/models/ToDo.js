export class ToDo {
    constructor(data) {
        this.description = data.description
        this.id = data.id
        this.completed = data.completed
        this.creatorId = data.creatorId
    }
}