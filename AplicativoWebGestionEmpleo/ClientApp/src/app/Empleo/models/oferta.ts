import { Empresa } from "./empresa";
import { Usuario } from "./usuario";

export class Oferta{
    ofertaId : Number;
    usuarioId : Number;
    resumen : string;
    estado : string;
    salario :string;
    cargo : string;
    tipoTrabajo: string;
    anoExperiencia : string;
    diponibilidadViajar: string;
    disponibilidadCambioResidendia:string;
    empresa : Empresa;
}
