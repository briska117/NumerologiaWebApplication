export interface Name {
    nameString: string
    letters: Letter[]
    totalLeatters: number
    totalConsonants: number
    totalVocals: number
    vocalReductions: VocalReduction[]
    consonantReductions: ConsonantReduction[]
    warning: boolean
}

export interface NumericalAnalisys {
  names: Name[]
  essenceInitial: number
  imageInitial: number
  essenceReductions: EssenceReduction[]
  imageReductions: ImageReduction[]
  essenceReductionString: string
  imageReductionString: string
}
  
  export interface Letter {
    character: string
    value: number
    isVocal: boolean
  }
  
  export interface VocalReduction {
    initialNum: number
    reductionNum: number
    reductionFormat: string
  }
  
  export interface ConsonantReduction {
    initialNum: number
    reductionNum?: number
    reductionFormat: string
  }
  
  export interface EssenceReduction {
    initialNum: number
    reductionNum: any
    reductionFormat: string
  }
  
  export interface ImageReduction {
    initialNum: number
    reductionNum: any
    reductionFormat: string
  }
