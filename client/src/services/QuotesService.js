import { AppState } from "../AppState.js"
import { Quote } from "../models/Quote.js"
import { logger } from "../utils/Logger.js"
import { bcwSandbox } from "./AxiosService.js"

class QuotesService {
    async getQuotes() {
        const res = await bcwSandbox.get('api/quotes')
        logger.log('getting quotes', res.data)
        AppState.quotes = new Quote(res.data)
    }
}
export const quotesService = new QuotesService()