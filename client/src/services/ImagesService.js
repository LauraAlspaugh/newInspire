import { AppState } from "../AppState.js"
import { Image } from "../models/Image.js"
import { logger } from "../utils/Logger.js"
import { api, bcwSandbox } from "./AxiosService.js"

class ImagesService {
    async getImages() {
        const res = await bcwSandbox.get('api/images')
        logger.log('getting images!', res.data)
        // AppState.images = res.data.map(pojo => new Image(pojo))
        AppState.images = new Image(res.data)
    }
}
export const imagesService = new ImagesService()