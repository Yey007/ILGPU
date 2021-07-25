using System;
using System.Text;

#nullable enable
#pragma warning disable 1591

namespace ILGPU.Backends.SPIRV {

    /// <summary>
    /// Defines utility methods to generate SPIRV operations
    /// </summary>
    [CLSCompliant(false)]
    public class StringSPIRVBuilder : ISPIRVBuilder {
    
        private StringBuilder _builder = new StringBuilder();
    
        public byte[] ToByteArray() => Encoding.UTF8.GetBytes(_builder.ToString());
    
        public void AddMetadata(uint magic, uint version, uint genMagic, uint bound, uint schema) {
            _builder.AppendLine($"; Magic: {magic:X}");
            _builder.AppendLine($"; Version: {version:X}");
            _builder.AppendLine($"; Generator Magic: {genMagic:X}");
            _builder.AppendLine($"; Bound: {bound}");
            _builder.AppendLine($"; Schema: {schema}");
        }
    
        public void Merge(ISPIRVBuilder other) {
            if(other == null) {
                throw new ArgumentNullException();
            }
    
            var otherString = other as StringSPIRVBuilder;
            if(otherString == null) {
                throw new InvalidCodeGenerationException(
                    "Attempted to merge binary builder with string representation builder"
                );
            }
    
            _builder.Append(otherString._builder);
        }
    
        public void GenerateOpNop() {
            _builder.Append("OpNop ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUndef(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUndef ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpSourceContinued(string ContinuedSource) {
            _builder.Append("OpSourceContinued ");
            _builder.Append("\"" + ContinuedSource + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSource(SourceLanguage param0, uint Version, uint? File = null, string? Source = null) {
            _builder.Append("OpSource ");
            _builder.Append(param0 + " ");
            _builder.Append(Version + " ");
            if(File != null) {
                _builder.Append("%" + File + " ");
            }
            if(Source != null) {
                _builder.Append("\"" + Source + "\" ");
            }
            _builder.AppendLine();
        }
        
        public void GenerateOpSourceExtension(string Extension) {
            _builder.Append("OpSourceExtension ");
            _builder.Append("\"" + Extension + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpName(uint Target, string Name) {
            _builder.Append("OpName ");
            _builder.Append("%" + Target + " ");
            _builder.Append("\"" + Name + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberName(uint Type, uint Member, string Name) {
            _builder.Append("OpMemberName ");
            _builder.Append("%" + Type + " ");
            _builder.Append(Member + " ");
            _builder.Append("\"" + Name + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpString(uint resultId, string String) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpString ");
            _builder.Append("\"" + String + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLine(uint File, uint Line, uint Column) {
            _builder.Append("OpLine ");
            _builder.Append("%" + File + " ");
            _builder.Append(Line + " ");
            _builder.Append(Column + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpExtension(string Name) {
            _builder.Append("OpExtension ");
            _builder.Append("\"" + Name + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExtInstImport(uint resultId, string Name) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpExtInstImport ");
            _builder.Append("\"" + Name + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExtInst(uint resultType, uint resultId, uint Set, uint Instruction, params uint[] Operand1Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpExtInst ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Set + " ");
            _builder.Append(Instruction + " ");
            for (int i = 0; i < Operand1Operand2.Length; i++) {
                _builder.Append("%" + Operand1Operand2[i] + " ");
            }
            _builder.AppendLine();
        }
        
        public void GenerateOpMemoryModel(AddressingModel param0, MemoryModel param1) {
            _builder.Append("OpMemoryModel ");
            _builder.Append(param0 + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEntryPoint(ExecutionModel param0, uint EntryPoint, string Name, params uint[] Interface) {
            _builder.Append("OpEntryPoint ");
            _builder.Append(param0 + " ");
            _builder.Append("%" + EntryPoint + " ");
            _builder.Append("\"" + Name + "\" ");
            for (int i = 0; i < Interface.Length; i++) {
                _builder.Append("%" + Interface[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecutionMode(uint EntryPoint, ExecutionMode Mode) {
            _builder.Append("OpExecutionMode ");
            _builder.Append("%" + EntryPoint + " ");
            _builder.Append(Mode + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpCapability(Capability Capability) {
            _builder.Append("OpCapability ");
            _builder.Append(Capability + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeVoid(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeVoid ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeBool(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeBool ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeInt(uint resultId, uint Width, uint Signedness) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeInt ");
            _builder.Append(Width + " ");
            _builder.Append(Signedness + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeFloat(uint resultId, uint Width) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeFloat ");
            _builder.Append(Width + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeVector(uint resultId, uint ComponentType, uint ComponentCount) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeVector ");
            _builder.Append("%" + ComponentType + " ");
            _builder.Append(ComponentCount + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeMatrix(uint resultId, uint ColumnType, uint ColumnCount) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeMatrix ");
            _builder.Append("%" + ColumnType + " ");
            _builder.Append(ColumnCount + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeImage(uint resultId, uint SampledType, Dim param2, uint Depth, uint Arrayed, uint MS, uint Sampled, ImageFormat param7, AccessQualifier? param8 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeImage ");
            _builder.Append("%" + SampledType + " ");
            _builder.Append(param2 + " ");
            _builder.Append(Depth + " ");
            _builder.Append(Arrayed + " ");
            _builder.Append(MS + " ");
            _builder.Append(Sampled + " ");
            _builder.Append(param7 + " ");
            if(param8 != null) {
                _builder.Append(param8 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeSampler(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeSampler ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeSampledImage(uint resultId, uint ImageType) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeSampledImage ");
            _builder.Append("%" + ImageType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeArray(uint resultId, uint ElementType, uint Length) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeArray ");
            _builder.Append("%" + ElementType + " ");
            _builder.Append("%" + Length + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeRuntimeArray(uint resultId, uint ElementType) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeRuntimeArray ");
            _builder.Append("%" + ElementType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeStruct(uint resultId, params uint[] Member0typemember1type) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeStruct ");
            for (int i = 0; i < Member0typemember1type.Length; i++) {
                _builder.Append("%" + Member0typemember1type[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeOpaque(uint resultId, string Thenameoftheopaquetype) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeOpaque ");
            _builder.Append("\"" + Thenameoftheopaquetype + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypePointer(uint resultId, StorageClass param1, uint Type) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypePointer ");
            _builder.Append(param1 + " ");
            _builder.Append("%" + Type + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeFunction(uint resultId, uint ReturnType, params uint[] Parameter0TypeParameter1Type) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeFunction ");
            _builder.Append("%" + ReturnType + " ");
            for (int i = 0; i < Parameter0TypeParameter1Type.Length; i++) {
                _builder.Append("%" + Parameter0TypeParameter1Type[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeEvent(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeEvent ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeDeviceEvent(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeDeviceEvent ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeReserveId(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeReserveId ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeQueue(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeQueue ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypePipe(uint resultId, AccessQualifier Qualifier) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypePipe ");
            _builder.Append(Qualifier + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeForwardPointer(uint PointerType, StorageClass param1) {
            _builder.Append("OpTypeForwardPointer ");
            _builder.Append("%" + PointerType + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantTrue(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstantTrue ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantFalse(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstantFalse ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstant(uint resultType, uint resultId, double Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstant ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantComposite(uint resultType, uint resultId, params uint[] Constituents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstantComposite ");
            _builder.Append("%" + resultType + " ");
            for (int i = 0; i < Constituents.Length; i++) {
                _builder.Append("%" + Constituents[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantSampler(uint resultType, uint resultId, SamplerAddressingMode param2, uint Param, SamplerFilterMode param4) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstantSampler ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(param2 + " ");
            _builder.Append(Param + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantNull(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstantNull ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantTrue(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSpecConstantTrue ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantFalse(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSpecConstantFalse ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstant(uint resultType, uint resultId, double Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSpecConstant ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantComposite(uint resultType, uint resultId, params uint[] Constituents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSpecConstantComposite ");
            _builder.Append("%" + resultType + " ");
            for (int i = 0; i < Constituents.Length; i++) {
                _builder.Append("%" + Constituents[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantOp(uint resultType, uint resultId, uint Opcode) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSpecConstantOp ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(Opcode + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunction(uint resultType, uint resultId, FunctionControl param2, uint FunctionType) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFunction ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(param2 + " ");
            _builder.Append("%" + FunctionType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunctionParameter(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFunctionParameter ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpFunctionEnd() {
            _builder.Append("OpFunctionEnd ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunctionCall(uint resultType, uint resultId, uint Function, params uint[] Argument0Argument1) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFunctionCall ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Function + " ");
            for (int i = 0; i < Argument0Argument1.Length; i++) {
                _builder.Append("%" + Argument0Argument1[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVariable(uint resultType, uint resultId, StorageClass param2, uint? Initializer = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVariable ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(param2 + " ");
            if(Initializer != null) {
                _builder.Append("%" + Initializer + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageTexelPointer(uint resultType, uint resultId, uint Image, uint Coordinate, uint Sample) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageTexelPointer ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Sample + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLoad(uint resultType, uint resultId, uint Pointer, MemoryAccess? param3 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLoad ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            if(param3 != null) {
                _builder.Append(param3 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpStore(uint Pointer, uint Object, MemoryAccess? param2 = null) {
            _builder.Append("OpStore ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Object + " ");
            if(param2 != null) {
                _builder.Append(param2 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyMemory(uint Target, uint Source, MemoryAccess? param2 = null, MemoryAccess? param3 = null) {
            _builder.Append("OpCopyMemory ");
            _builder.Append("%" + Target + " ");
            _builder.Append("%" + Source + " ");
            if(param2 != null) {
                _builder.Append(param2 + " ");
            }
            if(param3 != null) {
                _builder.Append(param3 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyMemorySized(uint Target, uint Source, uint Size, MemoryAccess? param3 = null, MemoryAccess? param4 = null) {
            _builder.Append("OpCopyMemorySized ");
            _builder.Append("%" + Target + " ");
            _builder.Append("%" + Source + " ");
            _builder.Append("%" + Size + " ");
            if(param3 != null) {
                _builder.Append(param3 + " ");
            }
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAccessChain(uint resultType, uint resultId, uint Base, params uint[] Indexes) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAccessChain ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            for (int i = 0; i < Indexes.Length; i++) {
                _builder.Append("%" + Indexes[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpInBoundsAccessChain(uint resultType, uint resultId, uint Base, params uint[] Indexes) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpInBoundsAccessChain ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            for (int i = 0; i < Indexes.Length; i++) {
                _builder.Append("%" + Indexes[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrAccessChain(uint resultType, uint resultId, uint Base, uint Element, params uint[] Indexes) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPtrAccessChain ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Element + " ");
            for (int i = 0; i < Indexes.Length; i++) {
                _builder.Append("%" + Indexes[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpArrayLength(uint resultType, uint resultId, uint Structure, uint Arraymember) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpArrayLength ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Structure + " ");
            _builder.Append(Arraymember + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGenericPtrMemSemantics(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGenericPtrMemSemantics ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpInBoundsPtrAccessChain(uint resultType, uint resultId, uint Base, uint Element, params uint[] Indexes) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpInBoundsPtrAccessChain ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Element + " ");
            for (int i = 0; i < Indexes.Length; i++) {
                _builder.Append("%" + Indexes[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorate(uint Target, Decoration param1) {
            _builder.Append("OpDecorate ");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberDecorate(uint StructureType, uint Member, Decoration param2) {
            _builder.Append("OpMemberDecorate ");
            _builder.Append("%" + StructureType + " ");
            _builder.Append(Member + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorationGroup(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDecorationGroup ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupDecorate(uint DecorationGroup, params uint[] Targets) {
            _builder.Append("OpGroupDecorate ");
            _builder.Append("%" + DecorationGroup + " ");
            for (int i = 0; i < Targets.Length; i++) {
                _builder.Append("%" + Targets[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupMemberDecorate(uint DecorationGroup, params PairIdRefLiteralInteger[] Targets) {
            _builder.Append("OpGroupMemberDecorate ");
            _builder.Append("%" + DecorationGroup + " ");
            for (int i = 0; i < Targets.Length; i++) {
                _builder.Append("%" + Targets[i].base0 + " ");
                _builder.Append(Targets[i].base1 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorExtractDynamic(uint resultType, uint resultId, uint Vector, uint Index) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVectorExtractDynamic ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorInsertDynamic(uint resultType, uint resultId, uint Vector, uint Component, uint Index) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVectorInsertDynamic ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Component + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorShuffle(uint resultType, uint resultId, uint Vector1, uint Vector2, params uint[] Components) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVectorShuffle ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector1 + " ");
            _builder.Append("%" + Vector2 + " ");
            for (int i = 0; i < Components.Length; i++) {
                _builder.Append(Components[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCompositeConstruct(uint resultType, uint resultId, params uint[] Constituents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCompositeConstruct ");
            _builder.Append("%" + resultType + " ");
            for (int i = 0; i < Constituents.Length; i++) {
                _builder.Append("%" + Constituents[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCompositeExtract(uint resultType, uint resultId, uint Composite, params uint[] Indexes) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCompositeExtract ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Composite + " ");
            for (int i = 0; i < Indexes.Length; i++) {
                _builder.Append(Indexes[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCompositeInsert(uint resultType, uint resultId, uint Object, uint Composite, params uint[] Indexes) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCompositeInsert ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Object + " ");
            _builder.Append("%" + Composite + " ");
            for (int i = 0; i < Indexes.Length; i++) {
                _builder.Append(Indexes[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyObject(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCopyObject ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTranspose(uint resultType, uint resultId, uint Matrix) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTranspose ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSampledImage(uint resultType, uint resultId, uint Image, uint Sampler) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSampledImage ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Sampler + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleDrefImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleDrefImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleDrefExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleDrefExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleProjImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleProjExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjDrefImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleProjDrefImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleProjDrefExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleProjDrefExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageFetch(uint resultType, uint resultId, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageFetch ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageGather(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint Component, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageGather ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Component + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageDrefGather(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageDrefGather ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageRead(uint resultType, uint resultId, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageRead ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageWrite(uint Image, uint Coordinate, uint Texel, ImageOperands? param3 = null) {
            _builder.Append("OpImageWrite ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Texel + " ");
            if(param3 != null) {
                _builder.Append(param3 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImage(uint resultType, uint resultId, uint SampledImage) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImage ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryFormat(uint resultType, uint resultId, uint Image) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQueryFormat ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryOrder(uint resultType, uint resultId, uint Image) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQueryOrder ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQuerySizeLod(uint resultType, uint resultId, uint Image, uint LevelofDetail) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQuerySizeLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + LevelofDetail + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQuerySize(uint resultType, uint resultId, uint Image) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQuerySize ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQueryLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQueryLevels(uint resultType, uint resultId, uint Image) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQueryLevels ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageQuerySamples(uint resultType, uint resultId, uint Image) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageQuerySamples ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertFToU(uint resultType, uint resultId, uint FloatValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertFToU ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + FloatValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertFToS(uint resultType, uint resultId, uint FloatValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertFToS ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + FloatValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertSToF(uint resultType, uint resultId, uint SignedValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertSToF ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertUToF(uint resultType, uint resultId, uint UnsignedValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertUToF ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + UnsignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUConvert(uint resultType, uint resultId, uint UnsignedValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUConvert ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + UnsignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSConvert(uint resultType, uint resultId, uint SignedValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSConvert ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFConvert(uint resultType, uint resultId, uint FloatValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFConvert ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + FloatValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpQuantizeToF16(uint resultType, uint resultId, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpQuantizeToF16 ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertPtrToU(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertPtrToU ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSatConvertSToU(uint resultType, uint resultId, uint SignedValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSatConvertSToU ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSatConvertUToS(uint resultType, uint resultId, uint UnsignedValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSatConvertUToS ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + UnsignedValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertUToPtr(uint resultType, uint resultId, uint IntegerValue) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertUToPtr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + IntegerValue + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrCastToGeneric(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPtrCastToGeneric ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGenericCastToPtr(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGenericCastToPtr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGenericCastToPtrExplicit(uint resultType, uint resultId, uint Pointer, StorageClass Storage) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGenericCastToPtrExplicit ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(Storage + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitcast(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitcast ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSNegate(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSNegate ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFNegate(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFNegate ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAdd(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFAdd(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpISub(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpISub ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFSub(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFSub ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIMul(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIMul ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFMul(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFMul ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUDiv(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUDiv ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSDiv(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSDiv ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFDiv(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFDiv ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUMod(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUMod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSRem(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSRem ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSMod(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSMod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFRem(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFRem ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFMod(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFMod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorTimesScalar(uint resultType, uint resultId, uint Vector, uint Scalar) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVectorTimesScalar ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Scalar + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMatrixTimesScalar(uint resultType, uint resultId, uint Matrix, uint Scalar) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpMatrixTimesScalar ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.Append("%" + Scalar + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVectorTimesMatrix(uint resultType, uint resultId, uint Vector, uint Matrix) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVectorTimesMatrix ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMatrixTimesVector(uint resultType, uint resultId, uint Matrix, uint Vector) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpMatrixTimesVector ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Matrix + " ");
            _builder.Append("%" + Vector + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMatrixTimesMatrix(uint resultType, uint resultId, uint LeftMatrix, uint RightMatrix) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpMatrixTimesMatrix ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + LeftMatrix + " ");
            _builder.Append("%" + RightMatrix + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpOuterProduct(uint resultType, uint resultId, uint Vector1, uint Vector2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpOuterProduct ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector1 + " ");
            _builder.Append("%" + Vector2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDot(uint resultType, uint resultId, uint Vector1, uint Vector2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDot ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector1 + " ");
            _builder.Append("%" + Vector2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAddCarry(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIAddCarry ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpISubBorrow(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpISubBorrow ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUMulExtended(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUMulExtended ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSMulExtended(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSMulExtended ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAny(uint resultType, uint resultId, uint Vector) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAny ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAll(uint resultType, uint resultId, uint Vector) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAll ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Vector + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsNan(uint resultType, uint resultId, uint x) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsNan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsInf(uint resultType, uint resultId, uint x) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsInf ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsFinite(uint resultType, uint resultId, uint x) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsFinite ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsNormal(uint resultType, uint resultId, uint x) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsNormal ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSignBitSet(uint resultType, uint resultId, uint x) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSignBitSet ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLessOrGreater(uint resultType, uint resultId, uint x, uint y) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLessOrGreater ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.Append("%" + y + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpOrdered(uint resultType, uint resultId, uint x, uint y) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpOrdered ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.Append("%" + y + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUnordered(uint resultType, uint resultId, uint x, uint y) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUnordered ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + x + " ");
            _builder.Append("%" + y + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLogicalEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalNotEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLogicalNotEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalOr(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLogicalOr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalAnd(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLogicalAnd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLogicalNot(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLogicalNot ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSelect(uint resultType, uint resultId, uint Condition, uint Object1, uint Object2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSelect ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Condition + " ");
            _builder.Append("%" + Object1 + " ");
            _builder.Append("%" + Object2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpINotEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpINotEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUGreaterThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUGreaterThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSGreaterThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSGreaterThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUGreaterThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUGreaterThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSGreaterThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSGreaterThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpULessThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpULessThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSLessThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSLessThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpULessThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpULessThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSLessThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSLessThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFOrdEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFUnordEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdNotEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFOrdNotEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordNotEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFUnordNotEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdLessThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFOrdLessThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordLessThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFUnordLessThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdGreaterThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFOrdGreaterThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordGreaterThan(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFUnordGreaterThan ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdLessThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFOrdLessThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordLessThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFUnordLessThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFOrdGreaterThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFOrdGreaterThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFUnordGreaterThanEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFUnordGreaterThanEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpShiftRightLogical(uint resultType, uint resultId, uint Base, uint Shift) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpShiftRightLogical ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Shift + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpShiftRightArithmetic(uint resultType, uint resultId, uint Base, uint Shift) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpShiftRightArithmetic ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Shift + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpShiftLeftLogical(uint resultType, uint resultId, uint Base, uint Shift) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpShiftLeftLogical ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Shift + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitwiseOr(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitwiseOr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitwiseXor(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitwiseXor ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitwiseAnd(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitwiseAnd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpNot(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpNot ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitFieldInsert(uint resultType, uint resultId, uint Base, uint Insert, uint Offset, uint Count) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitFieldInsert ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Insert + " ");
            _builder.Append("%" + Offset + " ");
            _builder.Append("%" + Count + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitFieldSExtract(uint resultType, uint resultId, uint Base, uint Offset, uint Count) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitFieldSExtract ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Offset + " ");
            _builder.Append("%" + Count + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitFieldUExtract(uint resultType, uint resultId, uint Base, uint Offset, uint Count) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitFieldUExtract ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.Append("%" + Offset + " ");
            _builder.Append("%" + Count + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitReverse(uint resultType, uint resultId, uint Base) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitReverse ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBitCount(uint resultType, uint resultId, uint Base) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBitCount ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Base + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdx(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDPdx ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdy(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDPdy ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFwidth(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFwidth ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdxFine(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDPdxFine ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdyFine(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDPdyFine ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFwidthFine(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFwidthFine ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdxCoarse(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDPdxCoarse ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDPdyCoarse(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpDPdyCoarse ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFwidthCoarse(uint resultType, uint resultId, uint P) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFwidthCoarse ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + P + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpEmitVertex() {
            _builder.Append("OpEmitVertex ");
            _builder.AppendLine();
        }
        
        public void GenerateOpEndPrimitive() {
            _builder.Append("OpEndPrimitive ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEmitStreamVertex(uint Stream) {
            _builder.Append("OpEmitStreamVertex ");
            _builder.Append("%" + Stream + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEndStreamPrimitive(uint Stream) {
            _builder.Append("OpEndStreamPrimitive ");
            _builder.Append("%" + Stream + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpControlBarrier(uint Execution, uint Memory, uint Semantics) {
            _builder.Append("OpControlBarrier ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemoryBarrier(uint Memory, uint Semantics) {
            _builder.Append("OpMemoryBarrier ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicLoad(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicLoad ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicStore(uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("OpAtomicStore ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicExchange(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicExchange ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicCompareExchange(uint resultType, uint resultId, uint Pointer, uint Memory, uint Equal, uint Unequal, uint Value, uint Comparator) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicCompareExchange ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Equal + " ");
            _builder.Append("%" + Unequal + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Comparator + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicCompareExchangeWeak(uint resultType, uint resultId, uint Pointer, uint Memory, uint Equal, uint Unequal, uint Value, uint Comparator) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicCompareExchangeWeak ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Equal + " ");
            _builder.Append("%" + Unequal + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Comparator + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicIIncrement(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicIIncrement ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicIDecrement(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicIDecrement ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicIAdd(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicIAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicISub(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicISub ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicSMin(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicSMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicUMin(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicUMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicSMax(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicSMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicUMax(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicUMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicAnd(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicAnd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicOr(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicOr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicXor(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicXor ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPhi(uint resultType, uint resultId, params PairIdRefIdRef[] VariableParent) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPhi ");
            _builder.Append("%" + resultType + " ");
            for (int i = 0; i < VariableParent.Length; i++) {
                _builder.Append("%" + VariableParent[i].base0 + " ");
                _builder.Append("%" + VariableParent[i].base1 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLoopMerge(uint MergeBlock, uint ContinueTarget, LoopControl param2) {
            _builder.Append("OpLoopMerge ");
            _builder.Append("%" + MergeBlock + " ");
            _builder.Append("%" + ContinueTarget + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSelectionMerge(uint MergeBlock, SelectionControl param1) {
            _builder.Append("OpSelectionMerge ");
            _builder.Append("%" + MergeBlock + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLabel(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpLabel ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBranch(uint TargetLabel) {
            _builder.Append("OpBranch ");
            _builder.Append("%" + TargetLabel + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBranchConditional(uint Condition, uint TrueLabel, uint FalseLabel, params uint[] Branchweights) {
            _builder.Append("OpBranchConditional ");
            _builder.Append("%" + Condition + " ");
            _builder.Append("%" + TrueLabel + " ");
            _builder.Append("%" + FalseLabel + " ");
            for (int i = 0; i < Branchweights.Length; i++) {
                _builder.Append(Branchweights[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSwitch(uint Selector, uint Default, params PairLiteralIntegerIdRef[] Target) {
            _builder.Append("OpSwitch ");
            _builder.Append("%" + Selector + " ");
            _builder.Append("%" + Default + " ");
            for (int i = 0; i < Target.Length; i++) {
                _builder.Append(Target[i].base0 + " ");
                _builder.Append("%" + Target[i].base1 + " ");
            }
            _builder.AppendLine();
        }
        
        public void GenerateOpKill() {
            _builder.Append("OpKill ");
            _builder.AppendLine();
        }
        
        public void GenerateOpReturn() {
            _builder.Append("OpReturn ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReturnValue(uint Value) {
            _builder.Append("OpReturnValue ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpUnreachable() {
            _builder.Append("OpUnreachable ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLifetimeStart(uint Pointer, uint Size) {
            _builder.Append("OpLifetimeStart ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(Size + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLifetimeStop(uint Pointer, uint Size) {
            _builder.Append("OpLifetimeStop ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append(Size + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupAsyncCopy(uint resultType, uint resultId, uint Execution, uint Destination, uint Source, uint NumElements, uint Stride, uint Event) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupAsyncCopy ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Destination + " ");
            _builder.Append("%" + Source + " ");
            _builder.Append("%" + NumElements + " ");
            _builder.Append("%" + Stride + " ");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupWaitEvents(uint Execution, uint NumEvents, uint EventsList) {
            _builder.Append("OpGroupWaitEvents ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + NumEvents + " ");
            _builder.Append("%" + EventsList + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupAll(uint resultType, uint resultId, uint Execution, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupAll ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupAny(uint resultType, uint resultId, uint Execution, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupAny ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupBroadcast(uint resultType, uint resultId, uint Execution, uint Value, uint LocalId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupBroadcast ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + LocalId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupIAdd(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupIAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFAdd(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupFAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMin(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupFMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMin(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupUMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMin(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupSMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMax(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupFMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMax(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupUMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMax(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupSMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReadPipe(uint resultType, uint resultId, uint Pipe, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReadPipe ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpWritePipe(uint resultType, uint resultId, uint Pipe, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpWritePipe ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReservedReadPipe(uint resultType, uint resultId, uint Pipe, uint ReserveId, uint Index, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReservedReadPipe ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + Index + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReservedWritePipe(uint resultType, uint resultId, uint Pipe, uint ReserveId, uint Index, uint Pointer, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReservedWritePipe ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + Index + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReserveReadPipePackets(uint resultType, uint resultId, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReserveReadPipePackets ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReserveWritePipePackets(uint resultType, uint resultId, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReserveWritePipePackets ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCommitReadPipe(uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("OpCommitReadPipe ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCommitWritePipe(uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("OpCommitWritePipe ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsValidReserveId(uint resultType, uint resultId, uint ReserveId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsValidReserveId ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetNumPipePackets(uint resultType, uint resultId, uint Pipe, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetNumPipePackets ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetMaxPipePackets(uint resultType, uint resultId, uint Pipe, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetMaxPipePackets ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupReserveReadPipePackets(uint resultType, uint resultId, uint Execution, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupReserveReadPipePackets ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupReserveWritePipePackets(uint resultType, uint resultId, uint Execution, uint Pipe, uint NumPackets, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupReserveWritePipePackets ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + NumPackets + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupCommitReadPipe(uint Execution, uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("OpGroupCommitReadPipe ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupCommitWritePipe(uint Execution, uint Pipe, uint ReserveId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("OpGroupCommitWritePipe ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Pipe + " ");
            _builder.Append("%" + ReserveId + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEnqueueMarker(uint resultType, uint resultId, uint Queue, uint NumEvents, uint WaitEvents, uint RetEvent) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpEnqueueMarker ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Queue + " ");
            _builder.Append("%" + NumEvents + " ");
            _builder.Append("%" + WaitEvents + " ");
            _builder.Append("%" + RetEvent + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpEnqueueKernel(uint resultType, uint resultId, uint Queue, uint Flags, uint NDRange, uint NumEvents, uint WaitEvents, uint RetEvent, uint Invoke, uint Param, uint ParamSize, uint ParamAlign, params uint[] LocalSize) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpEnqueueKernel ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Queue + " ");
            _builder.Append("%" + Flags + " ");
            _builder.Append("%" + NDRange + " ");
            _builder.Append("%" + NumEvents + " ");
            _builder.Append("%" + WaitEvents + " ");
            _builder.Append("%" + RetEvent + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            for (int i = 0; i < LocalSize.Length; i++) {
                _builder.Append("%" + LocalSize[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelNDrangeSubGroupCount(uint resultType, uint resultId, uint NDRange, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetKernelNDrangeSubGroupCount ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + NDRange + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelNDrangeMaxSubGroupSize(uint resultType, uint resultId, uint NDRange, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetKernelNDrangeMaxSubGroupSize ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + NDRange + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelWorkGroupSize(uint resultType, uint resultId, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetKernelWorkGroupSize ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelPreferredWorkGroupSizeMultiple(uint resultType, uint resultId, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetKernelPreferredWorkGroupSizeMultiple ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRetainEvent(uint Event) {
            _builder.Append("OpRetainEvent ");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReleaseEvent(uint Event) {
            _builder.Append("OpReleaseEvent ");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCreateUserEvent(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCreateUserEvent ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsValidEvent(uint resultType, uint resultId, uint Event) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsValidEvent ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Event + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSetUserEventStatus(uint Event, uint Status) {
            _builder.Append("OpSetUserEventStatus ");
            _builder.Append("%" + Event + " ");
            _builder.Append("%" + Status + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCaptureEventProfilingInfo(uint Event, uint ProfilingInfo, uint Value) {
            _builder.Append("OpCaptureEventProfilingInfo ");
            _builder.Append("%" + Event + " ");
            _builder.Append("%" + ProfilingInfo + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetDefaultQueue(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetDefaultQueue ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpBuildNDRange(uint resultType, uint resultId, uint GlobalWorkSize, uint LocalWorkSize, uint GlobalWorkOffset) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpBuildNDRange ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + GlobalWorkSize + " ");
            _builder.Append("%" + LocalWorkSize + " ");
            _builder.Append("%" + GlobalWorkOffset + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleDrefImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleDrefImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleDrefExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleDrefExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleProjImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, ImageOperands param4) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleProjExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append(param4 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjDrefImplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleProjDrefImplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseSampleProjDrefExplicitLod(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands param5) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseSampleProjDrefExplicitLod ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            _builder.Append(param5 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseFetch(uint resultType, uint resultId, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseFetch ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseGather(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint Component, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseGather ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Component + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseDrefGather(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint D, ImageOperands? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseDrefGather ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + D + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseTexelsResident(uint resultType, uint resultId, uint ResidentCode) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseTexelsResident ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ResidentCode + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpNoLine() {
            _builder.Append("OpNoLine ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFlagTestAndSet(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicFlagTestAndSet ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFlagClear(uint Pointer, uint Memory, uint Semantics) {
            _builder.Append("OpAtomicFlagClear ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSparseRead(uint resultType, uint resultId, uint Image, uint Coordinate, ImageOperands? param4 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSparseRead ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSizeOf(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSizeOf ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypePipeStorage(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypePipeStorage ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantPipeStorage(uint resultType, uint resultId, uint PacketSize, uint PacketAlignment, uint Capacity) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstantPipeStorage ");
            _builder.Append("%" + resultType + " ");
            _builder.Append(PacketSize + " ");
            _builder.Append(PacketAlignment + " ");
            _builder.Append(Capacity + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCreatePipeFromPipeStorage(uint resultType, uint resultId, uint PipeStorage) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCreatePipeFromPipeStorage ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PipeStorage + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelLocalSizeForSubgroupCount(uint resultType, uint resultId, uint SubgroupCount, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetKernelLocalSizeForSubgroupCount ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SubgroupCount + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGetKernelMaxNumSubgroups(uint resultType, uint resultId, uint Invoke, uint Param, uint ParamSize, uint ParamAlign) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGetKernelMaxNumSubgroups ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Invoke + " ");
            _builder.Append("%" + Param + " ");
            _builder.Append("%" + ParamSize + " ");
            _builder.Append("%" + ParamAlign + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeNamedBarrier(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeNamedBarrier ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpNamedBarrierInitialize(uint resultType, uint resultId, uint SubgroupCount) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpNamedBarrierInitialize ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SubgroupCount + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemoryNamedBarrier(uint NamedBarrier, uint Memory, uint Semantics) {
            _builder.Append("OpMemoryNamedBarrier ");
            _builder.Append("%" + NamedBarrier + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpModuleProcessed(string Process) {
            _builder.Append("OpModuleProcessed ");
            _builder.Append("\"" + Process + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecutionModeId(uint EntryPoint, ExecutionMode Mode) {
            _builder.Append("OpExecutionModeId ");
            _builder.Append("%" + EntryPoint + " ");
            _builder.Append(Mode + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorateId(uint Target, Decoration param1) {
            _builder.Append("OpDecorateId ");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformElect(uint resultType, uint resultId, uint Execution) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformElect ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformAll(uint resultType, uint resultId, uint Execution, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformAll ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformAny(uint resultType, uint resultId, uint Execution, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformAny ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformAllEqual(uint resultType, uint resultId, uint Execution, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformAllEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBroadcast(uint resultType, uint resultId, uint Execution, uint Value, uint Id) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBroadcast ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Id + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBroadcastFirst(uint resultType, uint resultId, uint Execution, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBroadcastFirst ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallot(uint resultType, uint resultId, uint Execution, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBallot ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformInverseBallot(uint resultType, uint resultId, uint Execution, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformInverseBallot ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotBitExtract(uint resultType, uint resultId, uint Execution, uint Value, uint Index) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBallotBitExtract ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotBitCount(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBallotBitCount ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotFindLSB(uint resultType, uint resultId, uint Execution, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBallotFindLSB ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBallotFindMSB(uint resultType, uint resultId, uint Execution, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBallotFindMSB ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffle(uint resultType, uint resultId, uint Execution, uint Value, uint Id) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformShuffle ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Id + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffleXor(uint resultType, uint resultId, uint Execution, uint Value, uint Mask) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformShuffleXor ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Mask + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffleUp(uint resultType, uint resultId, uint Execution, uint Value, uint Delta) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformShuffleUp ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformShuffleDown(uint resultType, uint resultId, uint Execution, uint Value, uint Delta) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformShuffleDown ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformIAdd(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformIAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFAdd(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformFAdd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformIMul(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformIMul ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFMul(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformFMul ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformSMin(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformSMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformUMin(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformUMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFMin(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformFMin ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformSMax(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformSMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformUMax(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformUMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformFMax(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformFMax ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBitwiseAnd(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBitwiseAnd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBitwiseOr(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBitwiseOr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformBitwiseXor(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformBitwiseXor ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformLogicalAnd(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformLogicalAnd ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformLogicalOr(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformLogicalOr ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformLogicalXor(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint Value, uint? ClusterSize = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformLogicalXor ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + Value + " ");
            if(ClusterSize != null) {
                _builder.Append("%" + ClusterSize + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformQuadBroadcast(uint resultType, uint resultId, uint Execution, uint Value, uint Index) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformQuadBroadcast ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformQuadSwap(uint resultType, uint resultId, uint Execution, uint Value, uint Direction) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformQuadSwap ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCopyLogical(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCopyLogical ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPtrEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrNotEqual(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPtrNotEqual ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrDiff(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPtrDiff ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpTerminateInvocation() {
            _builder.Append("OpTerminateInvocation ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupBallotKHR(uint resultType, uint resultId, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupBallotKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupFirstInvocationKHR(uint resultType, uint resultId, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupFirstInvocationKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAllKHR(uint resultType, uint resultId, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAllKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAnyKHR(uint resultType, uint resultId, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAnyKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAllEqualKHR(uint resultType, uint resultId, uint Predicate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAllEqualKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Predicate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupReadInvocationKHR(uint resultType, uint resultId, uint Value, uint Index) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupReadInvocationKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Value + " ");
            _builder.Append("%" + Index + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTraceRayKHR(uint Accel, uint RayFlags, uint CullMask, uint SBTOffset, uint SBTStride, uint MissIndex, uint RayOrigin, uint RayTmin, uint RayDirection, uint RayTmax, uint Payload) {
            _builder.Append("OpTraceRayKHR ");
            _builder.Append("%" + Accel + " ");
            _builder.Append("%" + RayFlags + " ");
            _builder.Append("%" + CullMask + " ");
            _builder.Append("%" + SBTOffset + " ");
            _builder.Append("%" + SBTStride + " ");
            _builder.Append("%" + MissIndex + " ");
            _builder.Append("%" + RayOrigin + " ");
            _builder.Append("%" + RayTmin + " ");
            _builder.Append("%" + RayDirection + " ");
            _builder.Append("%" + RayTmax + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecuteCallableKHR(uint SBTIndex, uint CallableData) {
            _builder.Append("OpExecuteCallableKHR ");
            _builder.Append("%" + SBTIndex + " ");
            _builder.Append("%" + CallableData + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConvertUToAccelerationStructureKHR(uint resultType, uint resultId, uint Accel) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConvertUToAccelerationStructureKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Accel + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpIgnoreIntersectionKHR() {
            _builder.Append("OpIgnoreIntersectionKHR ");
            _builder.AppendLine();
        }
        
        public void GenerateOpTerminateRayKHR() {
            _builder.Append("OpTerminateRayKHR ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeRayQueryKHR(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeRayQueryKHR ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryInitializeKHR(uint RayQuery, uint Accel, uint RayFlags, uint CullMask, uint RayOrigin, uint RayTMin, uint RayDirection, uint RayTMax) {
            _builder.Append("OpRayQueryInitializeKHR ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Accel + " ");
            _builder.Append("%" + RayFlags + " ");
            _builder.Append("%" + CullMask + " ");
            _builder.Append("%" + RayOrigin + " ");
            _builder.Append("%" + RayTMin + " ");
            _builder.Append("%" + RayDirection + " ");
            _builder.Append("%" + RayTMax + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryTerminateKHR(uint RayQuery) {
            _builder.Append("OpRayQueryTerminateKHR ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGenerateIntersectionKHR(uint RayQuery, uint HitT) {
            _builder.Append("OpRayQueryGenerateIntersectionKHR ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + HitT + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryConfirmIntersectionKHR(uint RayQuery) {
            _builder.Append("OpRayQueryConfirmIntersectionKHR ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryProceedKHR(uint resultType, uint resultId, uint RayQuery) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryProceedKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionTypeKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionTypeKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupIAddNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupIAddNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFAddNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupFAddNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMinNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupFMinNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMinNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupUMinNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMinNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupSMinNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupFMaxNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupFMaxNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupUMaxNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupUMaxNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupSMaxNonUniformAMD(uint resultType, uint resultId, uint Execution, GroupOperation Operation, uint X) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupSMaxNonUniformAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append(Operation + " ");
            _builder.Append("%" + X + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFragmentMaskFetchAMD(uint resultType, uint resultId, uint Image, uint Coordinate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFragmentMaskFetchAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFragmentFetchAMD(uint resultType, uint resultId, uint Image, uint Coordinate, uint FragmentIndex) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFragmentFetchAMD ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + FragmentIndex + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReadClockKHR(uint resultType, uint resultId, uint Execution) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReadClockKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpImageSampleFootprintNV(uint resultType, uint resultId, uint SampledImage, uint Coordinate, uint Granularity, uint Coarse, ImageOperands? param6 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpImageSampleFootprintNV ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SampledImage + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Granularity + " ");
            _builder.Append("%" + Coarse + " ");
            if(param6 != null) {
                _builder.Append(param6 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpGroupNonUniformPartitionNV(uint resultType, uint resultId, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpGroupNonUniformPartitionNV ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpWritePackedPrimitiveIndices4x8NV(uint IndexOffset, uint PackedIndices) {
            _builder.Append("OpWritePackedPrimitiveIndices4x8NV ");
            _builder.Append("%" + IndexOffset + " ");
            _builder.Append("%" + PackedIndices + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReportIntersectionNV(uint resultType, uint resultId, uint Hit, uint HitKind) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReportIntersectionNV ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Hit + " ");
            _builder.Append("%" + HitKind + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReportIntersectionKHR(uint resultType, uint resultId, uint Hit, uint HitKind) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReportIntersectionKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Hit + " ");
            _builder.Append("%" + HitKind + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpIgnoreIntersectionNV() {
            _builder.Append("OpIgnoreIntersectionNV ");
            _builder.AppendLine();
        }
        
        public void GenerateOpTerminateRayNV() {
            _builder.Append("OpTerminateRayNV ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTraceNV(uint Accel, uint RayFlags, uint CullMask, uint SBTOffset, uint SBTStride, uint MissIndex, uint RayOrigin, uint RayTmin, uint RayDirection, uint RayTmax, uint PayloadId) {
            _builder.Append("OpTraceNV ");
            _builder.Append("%" + Accel + " ");
            _builder.Append("%" + RayFlags + " ");
            _builder.Append("%" + CullMask + " ");
            _builder.Append("%" + SBTOffset + " ");
            _builder.Append("%" + SBTStride + " ");
            _builder.Append("%" + MissIndex + " ");
            _builder.Append("%" + RayOrigin + " ");
            _builder.Append("%" + RayTmin + " ");
            _builder.Append("%" + RayDirection + " ");
            _builder.Append("%" + RayTmax + " ");
            _builder.Append("%" + PayloadId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAccelerationStructureNV(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAccelerationStructureNV ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAccelerationStructureKHR(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAccelerationStructureKHR ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpExecuteCallableNV(uint SBTIndex, uint CallableDataId) {
            _builder.Append("OpExecuteCallableNV ");
            _builder.Append("%" + SBTIndex + " ");
            _builder.Append("%" + CallableDataId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeCooperativeMatrixNV(uint resultId, uint ComponentType, uint Execution, uint Rows, uint Columns) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeCooperativeMatrixNV ");
            _builder.Append("%" + ComponentType + " ");
            _builder.Append("%" + Execution + " ");
            _builder.Append("%" + Rows + " ");
            _builder.Append("%" + Columns + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixLoadNV(uint resultType, uint resultId, uint Pointer, uint Stride, uint ColumnMajor, MemoryAccess? param5 = null) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCooperativeMatrixLoadNV ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Stride + " ");
            _builder.Append("%" + ColumnMajor + " ");
            if(param5 != null) {
                _builder.Append(param5 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixStoreNV(uint Pointer, uint Object, uint Stride, uint ColumnMajor, MemoryAccess? param4 = null) {
            _builder.Append("OpCooperativeMatrixStoreNV ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Object + " ");
            _builder.Append("%" + Stride + " ");
            _builder.Append("%" + ColumnMajor + " ");
            if(param4 != null) {
                _builder.Append(param4 + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixMulAddNV(uint resultType, uint resultId, uint A, uint B, uint C) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCooperativeMatrixMulAddNV ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + A + " ");
            _builder.Append("%" + B + " ");
            _builder.Append("%" + C + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCooperativeMatrixLengthNV(uint resultType, uint resultId, uint Type) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCooperativeMatrixLengthNV ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Type + " ");
            _builder.AppendLine();
        }
        
        public void GenerateOpBeginInvocationInterlockEXT() {
            _builder.Append("OpBeginInvocationInterlockEXT ");
            _builder.AppendLine();
        }
        
        public void GenerateOpEndInvocationInterlockEXT() {
            _builder.Append("OpEndInvocationInterlockEXT ");
            _builder.AppendLine();
        }
        
        public void GenerateOpDemoteToHelperInvocationEXT() {
            _builder.Append("OpDemoteToHelperInvocationEXT ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIsHelperInvocationEXT(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIsHelperInvocationEXT ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleINTEL(uint resultType, uint resultId, uint Data, uint InvocationId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupShuffleINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Data + " ");
            _builder.Append("%" + InvocationId + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleDownINTEL(uint resultType, uint resultId, uint Current, uint Next, uint Delta) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupShuffleDownINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Current + " ");
            _builder.Append("%" + Next + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleUpINTEL(uint resultType, uint resultId, uint Previous, uint Current, uint Delta) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupShuffleUpINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Previous + " ");
            _builder.Append("%" + Current + " ");
            _builder.Append("%" + Delta + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupShuffleXorINTEL(uint resultType, uint resultId, uint Data, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupShuffleXorINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Data + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupBlockReadINTEL(uint resultType, uint resultId, uint Ptr) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupBlockReadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Ptr + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupBlockWriteINTEL(uint Ptr, uint Data) {
            _builder.Append("OpSubgroupBlockWriteINTEL ");
            _builder.Append("%" + Ptr + " ");
            _builder.Append("%" + Data + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageBlockReadINTEL(uint resultType, uint resultId, uint Image, uint Coordinate) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupImageBlockReadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageBlockWriteINTEL(uint Image, uint Coordinate, uint Data) {
            _builder.Append("OpSubgroupImageBlockWriteINTEL ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Data + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageMediaBlockReadINTEL(uint resultType, uint resultId, uint Image, uint Coordinate, uint Width, uint Height) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupImageMediaBlockReadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Width + " ");
            _builder.Append("%" + Height + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupImageMediaBlockWriteINTEL(uint Image, uint Coordinate, uint Width, uint Height, uint Data) {
            _builder.Append("OpSubgroupImageMediaBlockWriteINTEL ");
            _builder.Append("%" + Image + " ");
            _builder.Append("%" + Coordinate + " ");
            _builder.Append("%" + Width + " ");
            _builder.Append("%" + Height + " ");
            _builder.Append("%" + Data + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUCountLeadingZerosINTEL(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUCountLeadingZerosINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUCountTrailingZerosINTEL(uint resultType, uint resultId, uint Operand) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUCountTrailingZerosINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAbsISubINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAbsISubINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAbsUSubINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAbsUSubINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAddSatINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIAddSatINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUAddSatINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUAddSatINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAverageINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIAverageINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUAverageINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUAverageINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIAverageRoundedINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIAverageRoundedINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUAverageRoundedINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUAverageRoundedINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpISubSatINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpISubSatINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUSubSatINTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUSubSatINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpIMul32x16INTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpIMul32x16INTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpUMul32x16INTEL(uint resultType, uint resultId, uint Operand1, uint Operand2) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpUMul32x16INTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Operand1 + " ");
            _builder.Append("%" + Operand2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstFunctionPointerINTEL(uint resultType, uint resultId, uint Function) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpConstFunctionPointerINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Function + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFunctionPointerCallINTEL(uint resultType, uint resultId, params uint[] Operand1) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFunctionPointerCallINTEL ");
            _builder.Append("%" + resultType + " ");
            for (int i = 0; i < Operand1.Length; i++) {
                _builder.Append("%" + Operand1[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAsmTargetINTEL(uint resultType, uint resultId, string Asmtarget) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAsmTargetINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("\"" + Asmtarget + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAsmINTEL(uint resultType, uint resultId, uint Asmtype, uint Target, string Asminstructions, string Constraints) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAsmINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Asmtype + " ");
            _builder.Append("%" + Target + " ");
            _builder.Append("\"" + Asminstructions + "\" ");
            _builder.Append("\"" + Constraints + "\" ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAsmCallINTEL(uint resultType, uint resultId, uint Asm, params uint[] Argument0) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAsmCallINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Asm + " ");
            for (int i = 0; i < Argument0.Length; i++) {
                _builder.Append("%" + Argument0[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFMinEXT(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicFMinEXT ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFMaxEXT(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicFMaxEXT ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorateString(uint Target, Decoration param1) {
            _builder.Append("OpDecorateString ");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpDecorateStringGOOGLE(uint Target, Decoration param1) {
            _builder.Append("OpDecorateStringGOOGLE ");
            _builder.Append("%" + Target + " ");
            _builder.Append(param1 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberDecorateString(uint StructType, uint Member, Decoration param2) {
            _builder.Append("OpMemberDecorateString ");
            _builder.Append("%" + StructType + " ");
            _builder.Append(Member + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpMemberDecorateStringGOOGLE(uint StructType, uint Member, Decoration param2) {
            _builder.Append("OpMemberDecorateStringGOOGLE ");
            _builder.Append("%" + StructType + " ");
            _builder.Append(Member + " ");
            _builder.Append(param2 + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVmeImageINTEL(uint resultType, uint resultId, uint ImageType, uint Sampler) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVmeImageINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ImageType + " ");
            _builder.Append("%" + Sampler + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeVmeImageINTEL(uint resultId, uint ImageType) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeVmeImageINTEL ");
            _builder.Append("%" + ImageType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImePayloadINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcImePayloadINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcRefPayloadINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcRefPayloadINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcSicPayloadINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcSicPayloadINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcMcePayloadINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcMcePayloadINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcMceResultINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcMceResultINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeResultINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcImeResultINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeResultSingleReferenceStreamoutINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcImeResultSingleReferenceStreamoutINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeResultDualReferenceStreamoutINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcImeResultDualReferenceStreamoutINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeSingleReferenceStreaminINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcImeSingleReferenceStreaminINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcImeDualReferenceStreaminINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcImeDualReferenceStreaminINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcRefResultINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcRefResultINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeAvcSicResultINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeAvcSicResultINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL(uint resultType, uint resultId, uint SliceType, uint Qp) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultInterBaseMultiReferencePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL(uint resultType, uint resultId, uint ReferenceBasePenalty, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetInterBaseMultiReferencePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ReferenceBasePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL(uint resultType, uint resultId, uint SliceType, uint Qp) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultInterShapePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetInterShapePenaltyINTEL(uint resultType, uint resultId, uint PackedShapePenalty, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetInterShapePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PackedShapePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL(uint resultType, uint resultId, uint SliceType, uint Qp) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultInterDirectionPenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetInterDirectionPenaltyINTEL(uint resultType, uint resultId, uint DirectionCost, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetInterDirectionPenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + DirectionCost + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL(uint resultType, uint resultId, uint SliceType, uint Qp) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultIntraLumaShapePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL(uint resultType, uint resultId, uint SliceType, uint Qp) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultInterMotionVectorCostTableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultMediumPenaltyCostTableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultLowPenaltyCostTableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetMotionVectorCostFunctionINTEL(uint resultType, uint resultId, uint PackedCostCenterDelta, uint PackedCostTable, uint CostPrecision, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetMotionVectorCostFunctionINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PackedCostCenterDelta + " ");
            _builder.Append("%" + PackedCostTable + " ");
            _builder.Append("%" + CostPrecision + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL(uint resultType, uint resultId, uint SliceType, uint Qp) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultIntraLumaModePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SliceType + " ");
            _builder.Append("%" + Qp + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultNonDcLumaIntraPenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetDefaultIntraChromaModeBasePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetAcOnlyHaarINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetAcOnlyHaarINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL(uint resultType, uint resultId, uint SourceFieldPolarity, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetSourceInterlacedFieldPolarityINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SourceFieldPolarity + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL(uint resultType, uint resultId, uint ReferenceFieldPolarity, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetSingleReferenceInterlacedFieldPolarityINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ReferenceFieldPolarity + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL(uint resultType, uint resultId, uint ForwardReferenceFieldPolarity, uint BackwardReferenceFieldPolarity, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceSetDualReferenceInterlacedFieldPolaritiesINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ForwardReferenceFieldPolarity + " ");
            _builder.Append("%" + BackwardReferenceFieldPolarity + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToImePayloadINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceConvertToImePayloadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToImeResultINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceConvertToImeResultINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToRefPayloadINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceConvertToRefPayloadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToRefResultINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceConvertToRefResultINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToSicPayloadINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceConvertToSicPayloadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceConvertToSicResultINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceConvertToSicResultINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetMotionVectorsINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetMotionVectorsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterDistortionsINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterDistortionsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetBestInterDistortionsINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetBestInterDistortionsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterMajorShapeINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterMajorShapeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterMinorShapeINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterMinorShapeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterDirectionsINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterDirectionsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterMotionVectorCountINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterMotionVectorCountINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterReferenceIdsINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterReferenceIdsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL(uint resultType, uint resultId, uint PackedReferenceIds, uint PackedReferenceParameterFieldPolarities, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcMceGetInterReferenceInterlacedFieldPolaritiesINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + PackedReferenceParameterFieldPolarities + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeInitializeINTEL(uint resultType, uint resultId, uint SrcCoord, uint PartitionMask, uint SADAdjustment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeInitializeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + PartitionMask + " ");
            _builder.Append("%" + SADAdjustment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetSingleReferenceINTEL(uint resultType, uint resultId, uint RefOffset, uint SearchWindowConfig, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeSetSingleReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RefOffset + " ");
            _builder.Append("%" + SearchWindowConfig + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetDualReferenceINTEL(uint resultType, uint resultId, uint FwdRefOffset, uint BwdRefOffset, uint idSearchWindowConfig, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeSetDualReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + FwdRefOffset + " ");
            _builder.Append("%" + BwdRefOffset + " ");
            _builder.Append("%" + idSearchWindowConfig + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeRefWindowSizeINTEL(uint resultType, uint resultId, uint SearchWindowConfig, uint DualRef) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeRefWindowSizeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SearchWindowConfig + " ");
            _builder.Append("%" + DualRef + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeAdjustRefOffsetINTEL(uint resultType, uint resultId, uint RefOffset, uint SrcCoord, uint RefWindowSize, uint ImageSize) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeAdjustRefOffsetINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RefOffset + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + RefWindowSize + " ");
            _builder.Append("%" + ImageSize + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeConvertToMcePayloadINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeConvertToMcePayloadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetMaxMotionVectorCountINTEL(uint resultType, uint resultId, uint MaxMotionVectorCount, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeSetMaxMotionVectorCountINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + MaxMotionVectorCount + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetUnidirectionalMixDisableINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeSetUnidirectionalMixDisableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL(uint resultType, uint resultId, uint Threshold, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeSetEarlySearchTerminationThresholdINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Threshold + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeSetWeightedSadINTEL(uint resultType, uint resultId, uint PackedSadWeights, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeSetWeightedSadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PackedSadWeights + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithSingleReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithDualReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL(uint resultType, uint resultId, uint SrcImage, uint RefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL(uint resultType, uint resultId, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL(uint resultType, uint resultId, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithSingleReferenceStreamoutINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL(uint resultType, uint resultId, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithDualReferenceStreamoutINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL(uint resultType, uint resultId, uint SrcImage, uint RefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL(uint resultType, uint resultId, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload, uint StreaminComponents) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeEvaluateWithDualReferenceStreaminoutINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + StreaminComponents + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeConvertToMceResultINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeConvertToMceResultINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetSingleReferenceStreaminINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetSingleReferenceStreaminINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetDualReferenceStreaminINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetDualReferenceStreaminINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeStripSingleReferenceStreamoutINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeStripSingleReferenceStreamoutINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeStripDualReferenceStreamoutINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeStripDualReferenceStreamoutINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL(uint resultType, uint resultId, uint Payload, uint MajorShape) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeMotionVectorsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL(uint resultType, uint resultId, uint Payload, uint MajorShape) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeDistortionsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL(uint resultType, uint resultId, uint Payload, uint MajorShape) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetStreamoutSingleReferenceMajorShapeReferenceIdsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL(uint resultType, uint resultId, uint Payload, uint MajorShape, uint Direction) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeMotionVectorsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL(uint resultType, uint resultId, uint Payload, uint MajorShape, uint Direction) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeDistortionsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL(uint resultType, uint resultId, uint Payload, uint MajorShape, uint Direction) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetStreamoutDualReferenceMajorShapeReferenceIdsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.Append("%" + MajorShape + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetBorderReachedINTEL(uint resultType, uint resultId, uint ImageSelect, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetBorderReachedINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ImageSelect + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetTruncatedSearchIndicationINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetTruncatedSearchIndicationINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetUnidirectionalEarlySearchTerminationINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetWeightingPatternMinimumMotionVectorINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcImeGetWeightingPatternMinimumDistortionINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcFmeInitializeINTEL(uint resultType, uint resultId, uint SrcCoord, uint MotionVectors, uint MajorShapes, uint MinorShapes, uint Direction, uint PixelResolution, uint SadAdjustment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcFmeInitializeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + MotionVectors + " ");
            _builder.Append("%" + MajorShapes + " ");
            _builder.Append("%" + MinorShapes + " ");
            _builder.Append("%" + Direction + " ");
            _builder.Append("%" + PixelResolution + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcBmeInitializeINTEL(uint resultType, uint resultId, uint SrcCoord, uint MotionVectors, uint MajorShapes, uint MinorShapes, uint Direction, uint PixelResolution, uint BidirectionalWeight, uint SadAdjustment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcBmeInitializeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.Append("%" + MotionVectors + " ");
            _builder.Append("%" + MajorShapes + " ");
            _builder.Append("%" + MinorShapes + " ");
            _builder.Append("%" + Direction + " ");
            _builder.Append("%" + PixelResolution + " ");
            _builder.Append("%" + BidirectionalWeight + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefConvertToMcePayloadINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefConvertToMcePayloadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefSetBidirectionalMixDisableINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefSetBidirectionalMixDisableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefSetBilinearFilterEnableINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefSetBilinearFilterEnableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithSingleReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefEvaluateWithSingleReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithDualReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefEvaluateWithDualReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithMultiReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint PackedReferenceIds, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefEvaluateWithMultiReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL(uint resultType, uint resultId, uint SrcImage, uint PackedReferenceIds, uint PackedReferenceFieldPolarities, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefEvaluateWithMultiReferenceInterlacedINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + PackedReferenceFieldPolarities + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcRefConvertToMceResultINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcRefConvertToMceResultINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicInitializeINTEL(uint resultType, uint resultId, uint SrcCoord) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicInitializeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcCoord + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConfigureSkcINTEL(uint resultType, uint resultId, uint SkipBlockPartitionType, uint SkipMotionVectorMask, uint MotionVectors, uint BidirectionalWeight, uint SadAdjustment, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicConfigureSkcINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SkipBlockPartitionType + " ");
            _builder.Append("%" + SkipMotionVectorMask + " ");
            _builder.Append("%" + MotionVectors + " ");
            _builder.Append("%" + BidirectionalWeight + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConfigureIpeLumaINTEL(uint resultType, uint resultId, uint LumaIntraPartitionMask, uint IntraNeighbourAvailabilty, uint LeftEdgeLumaPixels, uint UpperLeftCornerLumaPixel, uint UpperEdgeLumaPixels, uint UpperRightEdgeLumaPixels, uint SadAdjustment, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicConfigureIpeLumaINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + LumaIntraPartitionMask + " ");
            _builder.Append("%" + IntraNeighbourAvailabilty + " ");
            _builder.Append("%" + LeftEdgeLumaPixels + " ");
            _builder.Append("%" + UpperLeftCornerLumaPixel + " ");
            _builder.Append("%" + UpperEdgeLumaPixels + " ");
            _builder.Append("%" + UpperRightEdgeLumaPixels + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConfigureIpeLumaChromaINTEL(uint resultType, uint resultId, uint LumaIntraPartitionMask, uint IntraNeighbourAvailabilty, uint LeftEdgeLumaPixels, uint UpperLeftCornerLumaPixel, uint UpperEdgeLumaPixels, uint UpperRightEdgeLumaPixels, uint LeftEdgeChromaPixels, uint UpperLeftCornerChromaPixel, uint UpperEdgeChromaPixels, uint SadAdjustment, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicConfigureIpeLumaChromaINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + LumaIntraPartitionMask + " ");
            _builder.Append("%" + IntraNeighbourAvailabilty + " ");
            _builder.Append("%" + LeftEdgeLumaPixels + " ");
            _builder.Append("%" + UpperLeftCornerLumaPixel + " ");
            _builder.Append("%" + UpperEdgeLumaPixels + " ");
            _builder.Append("%" + UpperRightEdgeLumaPixels + " ");
            _builder.Append("%" + LeftEdgeChromaPixels + " ");
            _builder.Append("%" + UpperLeftCornerChromaPixel + " ");
            _builder.Append("%" + UpperEdgeChromaPixels + " ");
            _builder.Append("%" + SadAdjustment + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetMotionVectorMaskINTEL(uint resultType, uint resultId, uint SkipBlockPartitionType, uint Direction) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetMotionVectorMaskINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SkipBlockPartitionType + " ");
            _builder.Append("%" + Direction + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConvertToMcePayloadINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicConvertToMcePayloadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL(uint resultType, uint resultId, uint PackedShapePenalty, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicSetIntraLumaShapePenaltyINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PackedShapePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL(uint resultType, uint resultId, uint LumaModePenalty, uint LumaPackedNeighborModes, uint LumaPackedNonDcPenalty, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicSetIntraLumaModeCostFunctionINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + LumaModePenalty + " ");
            _builder.Append("%" + LumaPackedNeighborModes + " ");
            _builder.Append("%" + LumaPackedNonDcPenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL(uint resultType, uint resultId, uint ChromaModeBasePenalty, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicSetIntraChromaModeCostFunctionINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + ChromaModeBasePenalty + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetBilinearFilterEnableINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicSetBilinearFilterEnableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetSkcForwardTransformEnableINTEL(uint resultType, uint resultId, uint PackedSadCoefficients, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicSetSkcForwardTransformEnableINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PackedSadCoefficients + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL(uint resultType, uint resultId, uint BlockBasedSkipType, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicSetBlockBasedRawSkipSadINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + BlockBasedSkipType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateIpeINTEL(uint resultType, uint resultId, uint SrcImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicEvaluateIpeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithSingleReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint RefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicEvaluateWithSingleReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + RefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithDualReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint FwdRefImage, uint BwdRefImage, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicEvaluateWithDualReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + FwdRefImage + " ");
            _builder.Append("%" + BwdRefImage + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithMultiReferenceINTEL(uint resultType, uint resultId, uint SrcImage, uint PackedReferenceIds, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicEvaluateWithMultiReferenceINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL(uint resultType, uint resultId, uint SrcImage, uint PackedReferenceIds, uint PackedReferenceFieldPolarities, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicEvaluateWithMultiReferenceInterlacedINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + SrcImage + " ");
            _builder.Append("%" + PackedReferenceIds + " ");
            _builder.Append("%" + PackedReferenceFieldPolarities + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicConvertToMceResultINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicConvertToMceResultINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetIpeLumaShapeINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetIpeLumaShapeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetBestIpeLumaDistortionINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetBestIpeLumaDistortionINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetBestIpeChromaDistortionINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetBestIpeChromaDistortionINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetPackedIpeLumaModesINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetPackedIpeLumaModesINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetIpeChromaModeINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetIpeChromaModeINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetPackedSkcLumaCountThresholdINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetPackedSkcLumaSumThresholdINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSubgroupAvcSicGetInterRawSadsINTEL(uint resultType, uint resultId, uint Payload) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSubgroupAvcSicGetInterRawSadsINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Payload + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpVariableLengthArrayINTEL(uint resultType, uint resultId, uint Lenght) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpVariableLengthArrayINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Lenght + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSaveMemoryINTEL(uint resultType, uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpSaveMemoryINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRestoreMemoryINTEL(uint Ptr) {
            _builder.Append("OpRestoreMemoryINTEL ");
            _builder.Append("%" + Ptr + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpLoopControlINTEL(params uint[] LoopControlParameters) {
            _builder.Append("OpLoopControlINTEL ");
            for (int i = 0; i < LoopControlParameters.Length; i++) {
                _builder.Append(LoopControlParameters[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpPtrCastToCrossWorkgroupINTEL(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpPtrCastToCrossWorkgroupINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpCrossWorkgroupCastToPtrINTEL(uint resultType, uint resultId, uint Pointer) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpCrossWorkgroupCastToPtrINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpReadPipeBlockingINTEL(uint resultType, uint resultId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpReadPipeBlockingINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpWritePipeBlockingINTEL(uint resultType, uint resultId, uint PacketSize, uint PacketAlignment) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpWritePipeBlockingINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + PacketSize + " ");
            _builder.Append("%" + PacketAlignment + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpFPGARegINTEL(uint resultType, uint resultId, uint Result, uint Input) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpFPGARegINTEL ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Result + " ");
            _builder.Append("%" + Input + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetRayTMinKHR(uint resultType, uint resultId, uint RayQuery) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetRayTMinKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetRayFlagsKHR(uint resultType, uint resultId, uint RayQuery) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetRayFlagsKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionTKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionTKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionInstanceCustomIndexKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionInstanceCustomIndexKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionInstanceIdKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionInstanceIdKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionInstanceShaderBindingTableRecordOffsetKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionGeometryIndexKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionGeometryIndexKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionPrimitiveIndexKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionPrimitiveIndexKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionBarycentricsKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionBarycentricsKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionFrontFaceKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionFrontFaceKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionCandidateAABBOpaqueKHR(uint resultType, uint resultId, uint RayQuery) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionCandidateAABBOpaqueKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionObjectRayDirectionKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionObjectRayDirectionKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionObjectRayOriginKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionObjectRayOriginKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetWorldRayDirectionKHR(uint resultType, uint resultId, uint RayQuery) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetWorldRayDirectionKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetWorldRayOriginKHR(uint resultType, uint resultId, uint RayQuery) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetWorldRayOriginKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionObjectToWorldKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionObjectToWorldKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpRayQueryGetIntersectionWorldToObjectKHR(uint resultType, uint resultId, uint RayQuery, uint Intersection) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpRayQueryGetIntersectionWorldToObjectKHR ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + RayQuery + " ");
            _builder.Append("%" + Intersection + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpAtomicFAddEXT(uint resultType, uint resultId, uint Pointer, uint Memory, uint Semantics, uint Value) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpAtomicFAddEXT ");
            _builder.Append("%" + resultType + " ");
            _builder.Append("%" + Pointer + " ");
            _builder.Append("%" + Memory + " ");
            _builder.Append("%" + Semantics + " ");
            _builder.Append("%" + Value + " ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeBufferSurfaceINTEL(uint resultId) {
            _builder.Append("%" + resultId + " = ");
            _builder.Append("OpTypeBufferSurfaceINTEL ");
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpTypeStructContinuedINTEL(params uint[] Member0typemember1type) {
            _builder.Append("OpTypeStructContinuedINTEL ");
            for (int i = 0; i < Member0typemember1type.Length; i++) {
                _builder.Append("%" + Member0typemember1type[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpConstantCompositeContinuedINTEL(params uint[] Constituents) {
            _builder.Append("OpConstantCompositeContinuedINTEL ");
            for (int i = 0; i < Constituents.Length; i++) {
                _builder.Append("%" + Constituents[i] + " ");
            }
            _builder.AppendLine();
        }
        
        [CLSCompliant(false)]
        public void GenerateOpSpecConstantCompositeContinuedINTEL(params uint[] Constituents) {
            _builder.Append("OpSpecConstantCompositeContinuedINTEL ");
            for (int i = 0; i < Constituents.Length; i++) {
                _builder.Append("%" + Constituents[i] + " ");
            }
            _builder.AppendLine();
        }
        
    }
}
#pragma warning restore 1591