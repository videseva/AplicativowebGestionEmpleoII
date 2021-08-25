import { Aspirante } from "./aspirante";
import { Oferta } from "./oferta";

export class Postulacion {

    postulacionId: Number;
    usuarioId: Number;
    aspirante: Aspirante;
    ofertaId: Number;
    fechaPostulacion: Date  = new Date();
    estado: Number;
    estadoPostulacion:number;
    oferta : Oferta;
}
